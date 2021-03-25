using System;
using UnityEngine;

public class CustomEventTrigger
{
    public Action OnTriggeringEvent;

    public void TriggerEvent()
    {
        OnTriggeringEvent.Invoke();
    }
}

