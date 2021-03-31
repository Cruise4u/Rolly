using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameEventManager gameEventManager;
    public GameObject playerGO;

    private Dictionary<string, LevelData> levelDataDictionary;
    private LevelData currentLevelData;

    private bool isLevelStarted;
    private bool isLevelFinished;

    public void EnablePlayer()
    {
        playerGO.SetActive(true);
    }
    public void OnDisablePlayer()
    {
        playerGO.SetActive(false);
    }
    public void LoadLevel(LevelData levelData)
    {
        SceneManager.LoadScene(levelData.sceneName, LoadSceneMode.Single);
        currentLevelData = levelData;
    }
    public void RestartLevel(LevelData levelData)
    {
        LoadLevel(levelData);
    }

    public void OnEnable()
    {
        EnablePlayer();
    }

    public void Start()
    {
        gameEventManager.NotifyObserversToEvent(EventName.StartLevel);
    }

}
