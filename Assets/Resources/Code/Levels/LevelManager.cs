using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>, IEventObserver
{
    #region Class Field Members
    public TimeController timeController;
    public GameObject playerGO;
    public LevelSpawner levelSpawner;
    public LevelData currentLevelData;
    public LevelName currentLevelName;
    #endregion
    public IEnumerator RespawnPlayerAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SpawnPlayer(levelSpawner);
        GameEventManager.Instance.NotifyObserversToEvent(EventName.StartLevel);
    }
    public void RestartLevel()
    {
        GameEventManager.Instance.UnsubscribeObserversToEvent();
        SceneManager.LoadScene(currentLevelName.ToString(), LoadSceneMode.Single);
    }
    public void EnablePlayer()
    {
        playerGO.SetActive(true);
    }
    public void DisablePlayer()
    {
        playerGO.SetActive(false);
    }
    public void SpawnPlayer(LevelSpawner level)
    {
        playerGO.transform.position = level.gameObject.transform.GetChild(0).transform.position;
    }
    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.EnterLevel:
                if(currentLevelName != LevelName.SceneLevelTutorial)
                {
                    SpawnPlayer(levelSpawner);
                    StartCoroutine(timeController.WaitForCountdownToStart());
                }
                else
                {
                    SpawnPlayer(levelSpawner);
                }
                break;
            case EventName.StartLevel:

                break;
            case EventName.Lose:
                if (currentLevelName != LevelName.SceneLevelTutorial)
                {
                    timeController.StopTimer();
                    GUIController.Instance.inGameCounterGO.SetActive(false);
                }
                else
                {
                    StartCoroutine(RespawnPlayerAfterSeconds(2.0f));
                }
                break;
            default:
                if (currentLevelName != LevelName.SceneLevelTutorial)
                {
                    timeController.StopTimer();
                    GUIController.Instance.inGameCounterGO.SetActive(false);
                }
                break;
        }
    }


    public void Start()
    {
        timeController = new TimeController();
        GameEventManager.Instance.NotifyObserversToEvent(EventName.EnterLevel);
    }
    public void Update()
    {
        if (timeController.isCountingEverySecond != false)
        {
            timeController.CountTimeElapsed(Time.deltaTime);
        }
    }
}
