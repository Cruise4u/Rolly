using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuController : Singleton<MenuController>
{
    public GameObject gameTitleGO;
    public Dictionary<int,LevelData> levelDictionary;
    public LevelData[] levelDataArray;

    public void LoadLevelByNumber(int number)
    {
        SceneManager.LoadScene(levelDictionary[number].sceneName, LoadSceneMode.Single);
    }

    public void DisplayMenu(int number)
    {
        if(number == 0)
        {
            gameObject.transform.GetChild(number).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameTitleGO.SetActive(true);
        }
        else if(number == 1)
        {
            gameObject.transform.GetChild(number).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameTitleGO.SetActive(false);
        }
        else if(number == 2)
        {
            gameObject.transform.GetChild(number).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameTitleGO.SetActive(false);
        }
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
