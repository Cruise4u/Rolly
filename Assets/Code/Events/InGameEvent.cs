using System;
using System.Collections.Generic;
using UnityEngine;

public interface IEvent
{
    void TriggerEvent();
}

public interface IEventListener<T> where T : IEvent
{
    void ListenToEvent(T tEvent);
}

//public class GameEventManager : MonoBehaviour
//{
//    public static GameEventManager inGameEventManager;
//    private List<IEventListener> listenerList;

//    public static GameEventManager instance
//    {
//        get
//        {
//            if (!inGameEventManager)
//            {
//                inGameEventManager = FindObjectOfType(typeof(GameEventManager)) as GameEventManager;

//                if (!inGameEventManager)
//                {
//                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
//                }
//                else
//                {
//                    inGameEventManager.Init();
//                }
//            }

//            return inGameEventManager;
//        }
//    }

//    public void Init()
//    {
//        if (inGameEventManager == null)
//        {
//            gameEventDictionary = new Dictionary<string, IEvent>();
//        }
//    }

//    public void SubscribeListener(string methodName,IEventListener listener)
//    {
//        if(!listenerList.Contains(listener))
//        {
//            listenerList.Add(listener);  
//        }
//    }

//    public void UnsubscribeListener(string methodName, IEventListener listener)
//    {
//        if(listenerList.Contains(listener))
//        {
//            listenerList.Remove(listener);
//        }
//    }

//}

public class WinEvent : IEvent
{
    public Action winDelegateAction;

    public static WinEvent winEvent;

    public void TriggerEvent()
    {
        winDelegateAction.Invoke();
    }
}

public class LoseEvent : IEvent
{
    public Action winDelegateAction;

    public static LoseEvent winEvent;
    public void TriggerEvent()
    {
        throw new NotImplementedException();
    }
}

public class PlayerScore : MonoBehaviour,IEventListener<WinEvent>
{
    public bool isLevelStarted;
    public bool isLevelFinished;

    public Action ScoreDelegate;

    public void ListenToEvent(WinEvent tEvent)
    {
        tEvent.winDelegateAction += ScoreDelegate;
    }

    public void AddScore()
    {

    }


}