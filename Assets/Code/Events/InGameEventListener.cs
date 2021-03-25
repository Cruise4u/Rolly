using System;
using UnityEngine;

public class InGameEventListener
{
    public Action DelegatedAction;

    public void ListenToEvent()
    {
        DelegatedAction.Invoke();
    }
}

