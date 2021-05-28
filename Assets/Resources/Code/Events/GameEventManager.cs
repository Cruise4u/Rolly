using System;
using System.Collections.Generic;
using UnityEngine;

public interface IEventObserver
{
    void Notified(EventName eventName);
}

public class GameEventManager : Singleton<GameEventManager>
{
    public Dictionary<EventName, GameEvent> gameEventDictionary;
    public void Init()
    {
        gameEventDictionary = new Dictionary<EventName, GameEvent>();
        GameEvent[] gameEvents = Resources.LoadAll<GameEvent>("Prefabs/Events");
        foreach (GameEvent gameEvent in gameEvents)
        {
            if (!gameEventDictionary.ContainsKey(gameEvent.eventName))
            {
                gameEventDictionary.Add(gameEvent.eventName, gameEvent);
            }
        }
    }
    public void NotifyObserversToEvent(EventName eventName)
    {
        GameEvent randomEvent = null;
        if(gameEventDictionary.TryGetValue(eventName, out randomEvent))
        {
            gameEventDictionary[eventName].NotifyObservers();
        }
    }
    public void SubscribeObserversToEvent()
    {
        foreach (GameEvent gameEvent in gameEventDictionary.Values)
        {
            if (gameEvent != null)
            {
                switch (gameEvent.eventName)
                {
                    case EventName.EnterLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                        //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                        break;
                    case EventName.ExitLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                        //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                        break;
                    case EventName.StartLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                        //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                        break;
                    case EventName.EndLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                        break;
                    case EventName.Win:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                        gameEvent.SubscribeObserver(FindObjectOfType<GUIController>());
                        //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                        break;
                    case EventName.Lose:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                        gameEvent.SubscribeObserver(FindObjectOfType<GUIController>());
                        //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                        break;
                    case EventName.StartBreaking:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        break;
                    case EventName.EndBreaking:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        break;
                }
            }
        }
    }
    public void UnsubscribeObserversToEvent()
    {
        foreach (GameEvent gameEvent in gameEventDictionary.Values)
        {
            switch (gameEvent.eventName)
            {
                case EventName.EnterLevel:
                    gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                    break;
                case EventName.ExitLevel:
                    gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                    break;
                case EventName.StartLevel:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerSounds>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    break;
                case EventName.EndLevel:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerSounds>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    break;
                case EventName.Win:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<GUIController>());
                    break;

                case EventName.Lose:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<GUIController>());
                    break;
                case EventName.StartBreaking:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    break;
                case EventName.EndBreaking:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    break;
            }
        }
    }
    public void Awake()
    {
        Init();
        SubscribeObserversToEvent();
    }
}

