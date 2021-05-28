using System;
using UnityEngine;

public class PlayerVisualEffects : MonoBehaviour,IEventObserver
{
    public DissolveShaderBehaviour dissolveShaderBehaviour;

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.Lose:
                dissolveShaderBehaviour.enabled = true;
                break;
            case EventName.StartLevel:
                dissolveShaderBehaviour.enabled = false;
                break;
        }
    }

}
