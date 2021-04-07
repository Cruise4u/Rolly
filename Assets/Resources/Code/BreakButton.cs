using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BreakButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameEventManager gameEventManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        GameEvent randomEvent = null;
        if (gameEventManager.gameEventDictionary.TryGetValue(EventName.StartBreaking, out randomEvent))
        {
            gameEventManager.NotifyObserversToEvent(EventName.StartBreaking);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameEvent randomEvent = null;
        if(gameEventManager.gameEventDictionary.TryGetValue(EventName.EndBreaking,out randomEvent))
        {
            gameEventManager.NotifyObserversToEvent(EventName.EndBreaking);
        }
    }
}
