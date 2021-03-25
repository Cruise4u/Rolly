using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Dictionary<string, int> LevelDictionary;
    public List<Scene> levelList;

    public bool isLevelStarted;
    public bool isLevelFinished;
    public bool boolean;

    public void OnEnable()
    {
    }

    public void OnDisable()
    {
        
    }

    public void FinishLevel()
    {
    }

    public void WinLevel()
    {
        
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(LevelDictionary[levelName], LoadSceneMode.Single);
    }

    public void RestartLevel(string levelName)
    {
        LoadLevel(levelName);
    }
}


