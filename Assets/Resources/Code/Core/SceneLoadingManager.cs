using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager
{
    public void LoadScene(LevelName levelName)
    {
        SceneManager.LoadScene(levelName.ToString(), LoadSceneMode.Single);
    }

    public Dictionary<string, Scene> sceneDictionary;


}
