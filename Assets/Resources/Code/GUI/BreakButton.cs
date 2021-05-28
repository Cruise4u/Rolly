using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BreakButton : Singleton<BreakButton>, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameEvent randomEvent = null;
        if (EventManager.Instance.gameEventDictionary.TryGetValue(EventName.StartBreaking, out randomEvent))
        {
            EventManager.Instance.NotifyObserversToEvent(EventName.StartBreaking);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameEvent randomEvent = null;
        if(EventManager.Instance.gameEventDictionary.TryGetValue(EventName.EndBreaking,out randomEvent))
        {
            EventManager.Instance.NotifyObserversToEvent(EventName.EndBreaking);
        }
    }
}
