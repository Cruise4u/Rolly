using System;
using System.Collections;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public GameManager gameManager;
    public int score;
    public bool isPlayerDefeated;

    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ReachGoal()
    {
        score += 1;
        gameManager.isLevelFinished = true;
        Debug.Log("You won :)");
    }

    public void ResetPlayerState()
    {
        isPlayerDefeated = false;
        score = 0;
    }

    public IEnumerator RestartLevelAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameManager.RestartLevel();
    }

    public void DefeatPlayer()
    {
        isPlayerDefeated = true;
        StartCoroutine(RestartLevelAfterSeconds(1.5f));
    }

}
