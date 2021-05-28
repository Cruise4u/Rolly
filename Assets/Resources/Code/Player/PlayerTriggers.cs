using System;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{


    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TagEnum.Win.ToString()))
        {
            GameEventManager.Instance.NotifyObserversToEvent(EventName.Win);
        }
        if (other.CompareTag(TagEnum.Defeat.ToString()))
        {
            GameEventManager.Instance.NotifyObserversToEvent(EventName.Lose);
        }
    }
}

public enum TagEnum
{
    Ground,
    Win,
    Defeat,
}