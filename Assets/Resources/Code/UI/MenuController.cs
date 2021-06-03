using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuController : Singleton<MenuController>
{
    public Dictionary<int,LevelData> levelDictionary;
    public LevelData[] levelDataArray;

    public void LoadLevelByNumber(int number)
    {
        SceneManager.LoadScene(levelDictionary[number].sceneName, LoadSceneMode.Single);
    }

    public void LoadMenu(int sceneBuildId)
    {
        SceneManager.LoadScene(sceneBuildId, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }

    public override void Awake()
    {
        base.Awake();
        if(levelDataArray.Length > 0)
        {
            levelDictionary = new Dictionary<int, LevelData>();
            foreach (int i in Enum.GetValues(typeof(LevelName)))
            {
                levelDictionary.Add(i, levelDataArray[i]);
            }
        }
    }

}
