using System;
using UnityEngine;

public class PlayerVisualEffects : MonoBehaviour,IGameEventObserver
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
