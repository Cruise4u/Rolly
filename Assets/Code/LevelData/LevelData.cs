using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum LevelName
{
    SceneLevel001,
    SceneLevel002,
    SceneLevel003,
    SceneLevel004,
    SceneLevel005,
}

[CreateAssetMenu(menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    public LevelName levelName;
    public string sceneName;

    public void OnValidate()
    {
        sceneName = levelName.ToString();
    }
}
