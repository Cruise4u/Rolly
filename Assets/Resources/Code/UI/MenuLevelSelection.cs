using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuLevelSelection : Singleton<MenuLevelSelection>
{
    public Dictionary<int,LevelData> levelDictionary;
    public LevelData[] levelDataArray;

    public void Awake()
    {
        levelDictionary = new Dictionary<int, LevelData>();
        foreach(int i in Enum.GetValues(typeof(LevelName)))
        {
            Debug.Log(i);
            levelDictionary.Add(i, levelDataArray[i]);
        }
    }

    public void LoadLevelByNumber(int number)
    {
        SceneManager.LoadScene(levelDictionary[number].sceneName, LoadSceneMode.Single);
    }
}
