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
                        gameEvent.SubscribeObserver(FindObjectOfType<GUIController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<TutorialManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<SoundController>());
                        break;
                    case EventName.ExitLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVFXController>());
                        break;
                    case EventName.StartLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVFXController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<SoundController>());
                        break;
                    case EventName.EndLevel:
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVFXController>());
                        break;
                    case EventName.Win:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerTriggers>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVFXController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<GUIController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelScore>());
                        gameEvent.SubscribeObserver(FindObjectOfType<SoundController>());
                        break;
                    case EventName.Lose:
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerPhysics>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerTriggers>());
                        gameEvent.SubscribeObserver(FindObjectOfType<PlayerVFXController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<GUIController>());
                        gameEvent.SubscribeObserver(FindObjectOfType<LevelScore>());
                        gameEvent.SubscribeObserver(FindObjectOfType<SoundController>());
                        break;
                    case EventName.Tutorial:
                        gameEvent.SubscribeObserver(FindObjectOfType<TutorialManager>());
                        gameEvent.SubscribeObserver(FindObjectOfType<GateManager>());
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
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerCamera>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<GUIController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<TutorialManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<SoundController>());
                    break;
                case EventName.ExitLevel:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerCamera>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    break;
                case EventName.StartLevel:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVFXController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<TutorialManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<SoundController>());
                    break;
                case EventName.EndLevel:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVFXController>());
                    break;
                case EventName.Win:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVFXController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerTriggers>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelScore>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<GUIController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<TutorialManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<SoundController>());
                    break;
                case EventName.Lose:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<GUIController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerVFXController>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerTriggers>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<LevelScore>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<SoundController>());
                    break;
                case EventName.StartBreaking:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    break;
                case EventName.EndBreaking:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<PlayerPhysics>());
                    break;
                case EventName.Tutorial:
                    gameEvent.UnsubscribeObserver(FindObjectOfType<TutorialManager>());
                    gameEvent.UnsubscribeObserver(FindObjectOfType<GateManager>());
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


    public void OnDestroy()
    {
        gameEventDictionary.Clear();
        UnsubscribeObserversToEvent();
    }

}

