using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour,IGameEventObserver
{
    public void Defeat()
    {
        Destroy(gameObject);
    }

    public void AddScore()
    {

    }

    public void SetScoreToZero()
    {

    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.Lose:
                Defeat();
                break;
        }
    }
}
