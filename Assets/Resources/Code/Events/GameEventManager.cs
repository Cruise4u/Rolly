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
            gameEventDictionary.Add(gameEvent.eventName, gameEvent);
        }
    }
    public void NotifyObserversToEvent(EventName eventName)
    {
        gameEventDictionary[eventName].NotifyObservers();
    }

    public void SubscribeObserversToEvent()
    {
        foreach (GameEvent gameEvent in Instance.gameEventDictionary.Values)
        {
            if (gameEvent != null)
            {
                switch (gameEvent.eventName)
                {
                    case EventName.EnterLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerCamera>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVFXController>());
                        //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                        break;
                    case EventName.ExitLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVFXController>());
                        //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                        break;
                    case EventName.StartLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVFXController>());
                        //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                        break;
                    case EventName.EndLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVFXController>());
                        break;
                    case EventName.Win:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVFXController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<GUIController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerTriggers>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                        break;
                    case EventName.Lose:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVFXController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<GUIController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerTriggers>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                        break;
                    case EventName.StartBreaking:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        break;
                    case EventName.EndBreaking:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        break;
                    case EventName.StartJumping:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        break;
                    case EventName.EndJumping:
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
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerCamera>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                    break;
                case EventName.ExitLevel:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerCamera>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                    break;
                case EventName.StartLevel:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVFXController>());
                    //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                    break;
                case EventName.EndLevel:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVFXController>());
                    //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                    break;
                case EventName.Win:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<GUIController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVFXController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerTriggers>());
                    //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
                    break;

                case EventName.Lose:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<GUIController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVFXController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerTriggers>());
                    //gameEvent.SubscribeObserver(FindObjectOfType<PlayerSounds>());
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

    public override void Awake()
    {
        base.Awake();
        Init();
        SubscribeObserversToEvent();
    }

    public void Start()
    {
        NotifyObserversToEvent(EventName.EnterLevel);
    }

    public void OnDestroy()
    {
        gameEventDictionary.Clear();
        UnsubscribeObserversToEvent();
    }

}

