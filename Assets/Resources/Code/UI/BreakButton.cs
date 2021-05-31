using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BreakButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameEvent randomEvent = null;
        if(GameEventManager.Instance.gameEventDictionary.TryGetValue(EventName.StartBreaking, out randomEvent))
        {
            GameEventManager.Instance.NotifyObserversToEvent(EventName.StartBreaking);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameEvent randomEvent = null;
        if(GameEventManager.Instance.gameEventDictionary.TryGetValue(EventName.EndBreaking,out randomEvent))
        {
            GameEventManager.Instance.NotifyObserversToEvent(EventName.EndBreaking);
        }
    }
}
