using System;
using UnityEngine;

public class PlayerTriggers : Singleton<PlayerTriggers>
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TagEnum.Win.ToString()))
        {
            EventManager.Instance.NotifyObserversToEvent(EventName.Win);
        }
        if (other.CompareTag(TagEnum.Defeat.ToString()))
        {
            EventManager.Instance.NotifyObserversToEvent(EventName.Lose);
            Destroy(gameObject, 1.0f);
        }
    }
}

public enum TagEnum
{
    Ground,
    Win,
    Defeat,
}