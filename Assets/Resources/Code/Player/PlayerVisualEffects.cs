using System;
using System.Collections;
using UnityEngine;

public class PlayerVisualEffects : Singleton<PlayerVisualEffects>, IGameEventObserver
{
    public DissolveShaderBehaviour dissolveShaderBehaviour;

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.Lose:
                dissolveShaderBehaviour.enabled = true;
                dissolveShaderBehaviour.TriggerDissolveEffect(2.0f);
                break;
            case EventName.StartLevel:
                dissolveShaderBehaviour.ResetDissolveEffect();
                dissolveShaderBehaviour.enabled = false;
                break;
        }
    }
}
