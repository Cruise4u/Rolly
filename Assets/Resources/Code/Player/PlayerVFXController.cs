using System;
using UnityEngine;

public class PlayerVFXController : Singleton<PlayerVFXController>,IEventObserver
{

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            default:
                DissolveShaderBehaviour.Instance.t = 0;
                DissolveShaderBehaviour.Instance.ResetEffect();
                DissolveShaderBehaviour.Instance.enabled = false;
                DissolveShaderBehaviour.Instance.isShaderActive = false;
                break;
            case EventName.Lose:

                DissolveShaderBehaviour.Instance.enabled = true;
                DissolveShaderBehaviour.Instance.isShaderActive = true;
                break;
        }
    }

}
