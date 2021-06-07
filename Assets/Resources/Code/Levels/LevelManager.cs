using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>,IEventObserver
{
    #region Class Field Members
    public TimeController timeController;
    public GameObject playerGO;
    public LevelSpawner levelSpawner;
    public LevelData currentLevelData;
    public LevelName currentLevelName;
    #endregion

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

    public void Start()
    {
        timeController = new TimeController();
        SpawnPlayer(levelSpawner);
    }
    public void Update()
    {
        if (timeController.isCountingEverySecond != false)
        {
            timeController.CountTimeElapsed(Time.deltaTime);
        }
    }
    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.EnterLevel:
                StartCoroutine(timeController.WaitForCountdownToStart());
                break;
            default:
                timeController.StopTimer();
                GUIController.Instance.inGameCounterGO.SetActive(false);
                break;
        }
    }
}
