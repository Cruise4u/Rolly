using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int inputCounter;

    public void Start()
    {
        inputCounter = 1;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(inputCounter > 0)
        {
            GameEventManager.Instance.NotifyObserversToEvent(EventName.StartJumping);
            inputCounter = 0;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameEventManager.Instance.NotifyObserversToEvent(EventName.EndJumping);
        inputCounter = 1;
    }
}
