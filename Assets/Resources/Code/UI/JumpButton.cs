using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour,IPointerUpHandler
{
    public int inputCounter;

    public void JumpAction()
    {

    }

    public void Start()
    {
        inputCounter = 1;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameEventManager.Instance.NotifyObserversToEvent(EventName.EndJumping);
        inputCounter = 1;
    }
}
