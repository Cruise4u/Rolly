using System;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEventObserver
{
    void Notified(EventName eventName);
}