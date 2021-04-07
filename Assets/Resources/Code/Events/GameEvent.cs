using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    public EventName eventName;

    private List<IGameEventObserver> observersList = new List<IGameEventObserver>();

    public void SubscribeObserver(IGameEventObserver observer)
    {
        observersList.Add(observer);
    }

    public void UnsubscribeObserver(IGameEventObserver observer)
    {
        observersList.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach(IGameEventObserver observer in observersList)
        {
            observer.Notified(eventName);
        }
    }
}

public enum EventName
{
    StartLevel,
    EndLevel,
    StartBreaking,
    EndBreaking,
    Win,
    Lose,
}