using System;
using UnityEngine;

public class PlayerVFXController : Singleton<PlayerVFXController>,IEventObserver
{

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            default:
                Debug.Log("Enabling!");
                DissolveShaderBehaviour.Instance.enabled = false;
                DissolveShaderBehaviour.Instance.isShaderActive = false;
                break;
            case EventName.Lose:

                Debug.Log("Disabling!");
                DissolveShaderBehaviour.Instance.enabled = true;
                DissolveShaderBehaviour.Instance.isShaderActive = true;
                break;
        }
    }

}
