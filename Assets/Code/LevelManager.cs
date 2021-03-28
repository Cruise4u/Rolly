using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameEvent startGameEvent;
    public GameObject playerGO;

    private Dictionary<string, LevelData> levelDataDictionary;
    private LevelData currentLevelData;

    private bool isLevelStarted;
    private bool isLevelFinished;

    public void EnablePlayer()
    {
        playerGO.SetActive(true);
        startGameEvent.SubscribeObserver(FindObjectOfType<TimeController>());
    }
    public void OnDisablePlayer()
    {
        startGameEvent.UnsubscribeObserver(playerGO.GetComponent<GUIController>());
        playerGO.SetActive(false);
    }
    public void LoadLevel(LevelData levelData)
    {
        SceneManager.LoadScene(levelData.sceneName, LoadSceneMode.Single);
        currentLevelData = levelData;
    }
    public void RestartLevel()
    {
        LoadLevel(currentLevelData);
    }
    public IEnumerator StartLevelAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void OnEnable()
    {
        EnablePlayer();
        startGameEvent.NotifyObservers();
    }

    public void OnDisable()
    {

    }

    public void Start()
    {
        StartCoroutine(StartLevelAfterSeconds(1.0f));
    }
}
