﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Dictionary<string, int> LevelDictionary;
    public List<Scene> levelList;

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(LevelDictionary[levelName], LoadSceneMode.Single);
    }

    public void RestartLevel(string levelName)
    {
        LoadLevel(levelName);
    }
}


