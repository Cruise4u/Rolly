﻿using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    public EventName eventName;

    private List<IEventObserver> observersList = new List<IEventObserver>();

    public void SubscribeObserver(IEventObserver observer)
    {
        observersList.Add(observer);
    }

    public void UnsubscribeObserver(IEventObserver observer)
    {
        observersList.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach(IEventObserver observer in observersList)
        {
            observer.Notified(eventName);
        }
    }
}

public enum EventName
{
    EndBreaking,
    EndLevel,
    EnterLevel,
    ExitLevel,
    Lose,
    PauseLevel,
    StartBreaking,
    StartLevel,
    Win,
}