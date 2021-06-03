using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public Dictionary<int, LevelData> levelScoreDictionary;

    public void Awake()
    {
        levelScoreDictionary = new Dictionary<int, LevelData>();
    }

    public void AddScore()
    {

    }

    public void SetScoreToZero()
    {

    }
}
