using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelScore : Singleton<LevelScore>,IEventObserver
{
    public Dictionary<int, LevelData> levelScoreDictionary;
    int currentScore;

    public override void Awake()
    {
        base.Awake();
        levelScoreDictionary = new Dictionary<int, LevelData>();
    }

    public void ReadScoreFromCounter()
    {
        currentScore = Mathf.FloorToInt(LevelManager.Instance.timeController.inGameCounter);
    }

    public void SetScoreForLevel(LevelData levelData)
    {
        if(levelData.scoreGoalArray.Length > 0)
        {
            if (currentScore <= levelData.scoreGoalArray[2])
            {
                GUIController.Instance.AttributeStarToScoreUI(3);
            }
            else if (currentScore > levelData.scoreGoalArray[2] && currentScore <= levelData.scoreGoalArray[1])
            {
                GUIController.Instance.AttributeStarToScoreUI(2);
            }
            else if (currentScore > levelData.scoreGoalArray[1])
            {
                GUIController.Instance.AttributeStarToScoreUI(3);
            }
        }
    }

    public void AddScore()
    {

    }

    public void ResetScore()
    {

    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.Win:
                ReadScoreFromCounter();
                SetScoreForLevel(LevelManager.Instance.currentLevelData);
                break;
        }
    }

}
