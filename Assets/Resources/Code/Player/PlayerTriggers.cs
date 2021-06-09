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
                SoundController.Instance.PlaySound("WinSound");
                break;

            case EventName.Lose:
                SoundController.Instance.PlaySound("LoseSound");
                break;

            case EventName.EnterLevel:
                SoundController.Instance.PlayMusic(LevelManager.Instance.currentLevelName.ToString());
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
        if (other.CompareTag(TagEnum.Tutorial.ToString()))
        {
            GameEventManager.Instance.NotifyObserversToEvent(EventName.Tutorial);
            Destroy(other.gameObject);
        }
    }
}

public enum TagEnum
{
    Ground,
    Win,
    Defeat,
    Tutorial,
}