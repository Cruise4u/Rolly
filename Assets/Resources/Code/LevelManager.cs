using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>,IEventObserver
{
    #region Class Field Members
    public GameObject playerGO;
    public TimeController timeController;
    public LevelData levelSelectMenuData;
    private LevelData currentLevelData;
    private Dictionary<string, LevelData> levelDataDictionary;
    private bool isLevelStarted;
    private bool isLevelFinished;
    #endregion

    public void LoadLevel(LevelData levelData)
    {
        SceneManager.LoadScene(levelData.sceneName, LoadSceneMode.Single);
        currentLevelData = levelData;
    }
    public void RestartLevel(LevelData levelData)
    {
        LoadLevel(levelData);
    }
    public void LoadLevelSelectMenu()
    {
        LoadLevel(levelSelectMenuData);
    }
    public bool CheckIfIsLastLevel()
    {
        bool condition = false;
        int numOfLevels = levelDataDictionary.Count;
        if(levelDataDictionary[currentLevelData.sceneName].levelName == LevelName.SceneLevel005)
        {
            condition = true;
        }
        else
        {
            condition = false;
        }
        return condition;
    }
    public void EnablePlayer()
    {
        playerGO.SetActive(true);
    }
    public void DisablePlayer()
    {
        playerGO.SetActive(false);
    }
    public void SpawnPlayer(LevelData levelData)
    {
        playerGO.transform.position = levelData.sceneBaseGO.transform.position;
    }

    public void Start()
    {
        SpawnPlayer(currentLevelData);
        GameEventManager.Instance.NotifyObserversToEvent(EventName.EnterLevel);
    }

    public void Update()
    {
        if(timeController.isCountingEverySecond != false)
        {
            timeController.CountTimeElapsed(Time.deltaTime);
        }
    }

    public void Notified(EventName eventName)
    {
        throw new NotImplementedException();
    }
}
