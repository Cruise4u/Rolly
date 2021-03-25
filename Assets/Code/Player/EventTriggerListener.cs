using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class EventTriggerListener : MonoBehaviour
{
    public PlayerState playerState;

    public CustomEventTrigger LevelStartEvent;
    
    
    
    public CustomEventTrigger winEvent;
    public CustomEventTrigger defeatEvent;

    public void Start()
    {
        winEvent = new CustomEventTrigger();
        defeatEvent = new CustomEventTrigger();
        defeatEvent.OnTriggeringEvent += playerState.DefeatPlayer;
        winEvent.OnTriggeringEvent += playerState.ReachGoal;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Defeat"))
        {
            defeatEvent.TriggerEvent();
        }
        if (other.CompareTag("Win"))
        {
            winEvent.TriggerEvent();
        }
    }
}



