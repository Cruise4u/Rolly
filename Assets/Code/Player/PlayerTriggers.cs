using System;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    public GameEvent winGameEvent;
    public GameEvent loseGameEvent;

    public bool isPlayerDefeated;
    TagEnum tagEnum;

    public void Init()
    {
        winGameEvent.SubscribeObserver(FindObjectOfType<GUIController>());
    }

    public void Terminate()
    {
        winGameEvent.UnsubscribeObserver(FindObjectOfType<GUIController>());
    }

    public void ReachGoal()
    {
        winGameEvent.NotifyObservers();
    }

    public void DefeatPlayer()
    {
        loseGameEvent.NotifyObservers();
    }

    public void OnEnable()
    {
        Init();
    }

    public void OnDisable()
    {
        Terminate();
    }

    //public IEnumerator RestartLevelAfterSeconds(float seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    gameManager.RestartLevel();
    //}

    //public void DefeatPlayer()
    //{
    //    isPlayerDefeated = true;
    //    StartCoroutine(RestartLevelAfterSeconds(1.5f));
    //}

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TagEnum.Win.ToString()))
        {
            Debug.Log(TagEnum.Win.ToString());
            ReachGoal();
        }
        if (other.CompareTag(TagEnum.Defeat.ToString()))
        {
            Debug.Log(TagEnum.Defeat.ToString());
            DefeatPlayer();
        }
    }

}

