using System;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEventObserver
{
    void Notified(EventName eventName);
}

public class EventManager : Singleton<EventManager>
{
    public Dictionary<EventName, GameEvent> gameEventDictionary;
    public void Init()
    {
        gameEventDictionary = new Dictionary<EventName, GameEvent>();
        GameEvent[] gameEvents = Resources.LoadAll<GameEvent>("Prefabs/Events");
        foreach (GameEvent gameEvent in gameEvents)
        {
            if(!gameEventDictionary.ContainsKey(gameEvent.eventName))
            {
                gameEventDictionary.Add(gameEvent.eventName, gameEvent);
            }
        }
    }
    public void NotifyObserversToEvent(EventName eventName)
    {
        GameEvent randomEvent = null;
        if (gameEventDictionary.TryGetValue(eventName, out randomEvent))
        {
            Debug.Log(gameEventDictionary[eventName]);
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
                        gameEvent.SubscribeObserver(FindObjectOfType<CameraHandler>());
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        break;
                    case EventName.StartLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                        break;
                    case EventName.EndLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                        break;
                    case EventName.Win:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                        gameEvent.SubscribeObserver(FindObjectOfType<GUIController>());
                        break;
                    case EventName.Lose:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                        gameEvent.SubscribeObserver(FindObjectOfType<GUIController>());
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
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    break;
                case EventName.StartLevel:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                    break;
                case EventName.EndLevel:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                    break;
                case EventName.Win:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<GUIController>());
                    break;
                case EventName.Lose:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVisualEffects>());
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

    public void Start()
    {
        Init();
        SubscribeObserversToEvent();
    }

    public void OnDestroy()
    {
        UnsubscribeObserversToEvent();
    }

}

