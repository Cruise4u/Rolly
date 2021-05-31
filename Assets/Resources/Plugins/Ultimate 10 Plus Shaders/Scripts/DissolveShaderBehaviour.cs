using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class DissolveShaderBehaviour : Singleton<DissolveShaderBehaviour>,IEventObserver
{
    public float speed = 0.5f;
    private float t = 0.0f;
    private MeshRenderer meshRenderer;
    private Material[] mats;

    public bool isShaderActive;

    private void Start(){
        meshRenderer = GetComponent<MeshRenderer>();
        mats = meshRenderer.materials;
    }

    private void DissolveEffect()
    {
        mats[0].SetFloat("_Cutoff", Mathf.Sin(t * speed));
        t += Time.deltaTime;
        meshRenderer.materials = mats;
    }

    private void Update()
    {
        if (isShaderActive != false)
        {
            DissolveEffect();
        }
    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.Lose:
                isShaderActive = true;
                break;
            default:
                isShaderActive = false;
                break;
        }
    }
}
