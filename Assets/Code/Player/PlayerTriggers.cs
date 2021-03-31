using System;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour,IGameEventObserver
{
    public GameEventManager gameEventManager;

    public bool isPlayerDefeated;

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.Win:
                break;
            case EventName.Lose:
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TagEnum.Win.ToString()))
        {
            gameEventManager.NotifyObserversToEvent(EventName.Win);
        }
        if (other.CompareTag(TagEnum.Defeat.ToString()))
        {
            gameEventManager.NotifyObserversToEvent(EventName.Lose);
        }
    }


}

public enum TagEnum
{
    Ground,
    Win,
    Defeat,
}