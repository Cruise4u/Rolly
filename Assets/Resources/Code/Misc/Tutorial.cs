using System;
using UnityEngine;

public class Tutorial : Singleton<Tutorial>,IEventObserver
{
    public void Init() 
    { 
    
    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.EnterLevel:
                Debug.Log("On Enter Level");
                GameEventManager.Instance.NotifyObserversToEvent(EventName.StartLevel);
                break;
        }
    }

    public void Start()
    {
        
    }


}
