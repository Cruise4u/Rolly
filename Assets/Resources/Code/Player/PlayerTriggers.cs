using System;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour,IEventObserver
{
    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.Win:
                GUIController.Instance.inputGO.SetActive(false);
                gameObject.SetActive(false);
                break;

            case EventName.Lose:

                break;

            case EventName.EnterLevel:

                break;
        }
    }

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