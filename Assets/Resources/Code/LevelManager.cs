using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>,IGameEventObserver
{
    #region LevelManager field members
    private Dictionary<string, LevelData> levelDataDictionary;
    public LevelData levelSelectMenuData;
    public LevelData currentLevelData;
    public GameObject playerGO;
    public TimeController timeController;
    private bool isLevelStarted;
    private bool isLevelFinished;

    #endregion

    public void LoadLevel(LevelData levelData)
    {
        SceneManager.LoadScene(levelData.sceneName, LoadSceneMode.Single);
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
    public void SpawnPlayerOnBase(LevelData levelData)
    {
        playerGO.transform.position = levelData.sceneBase.transform.position;
    }
    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.EnterLevel:
                timeController.ResetTimer();
                SpawnPlayerOnBase(currentLevelData);
                StartCoroutine(timeController.WaitForCountdownToStart());
                break;
            case EventName.Lose:
                timeController.StopTimer();
                break;
        }
    }

    public void Start()
    {
        timeController = new TimeController();
    }

    void Update()
    {
        if(timeController.isCountingEverySecond != false)
        {
            timeController.CountdownElapsedTime(GUIController.Instance.inGameCounterGO, Time.deltaTime);
        }
    }
}
