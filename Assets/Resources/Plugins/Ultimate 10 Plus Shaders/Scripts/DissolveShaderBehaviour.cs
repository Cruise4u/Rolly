using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class DissolveShaderBehaviour : Singleton<DissolveShaderBehaviour>
{
    public bool isEffectActive;
    public float dissolveSpeed;
    public float dissolveTime;
    private MeshRenderer meshRenderer;
    private Material[] mats;

    public IEnumerator WaitForSecondsToStopEffect(float time)
    {
        StartEffect();
        yield return new WaitForSeconds(time);
        StopEffect();
    }

    public void DissolveMaterialEverySecond(float time)
    {
        dissolveTime += time;
        mats[0].SetFloat("_Cutoff", Mathf.Sin(dissolveTime * dissolveSpeed));
        meshRenderer.materials = mats;
    }
    
    public void StartEffect()
    {
        isEffectActive = true;
    }

    public void StopEffect()
    {
        isEffectActive = false;
    }

    public void TriggerDissolveEffect(float time)
    {
        StartCoroutine(WaitForSecondsToStopEffect(time));
    }

    public void ResetDissolveEffect()
    {
        dissolveTime = 0.0f;
        StopEffect();
    }

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        mats = meshRenderer.materials;
        dissolveTime = Mathf.Clamp(dissolveTime, 0.0f, 1.0f);
    }

    public void Update()
    {
        if(isEffectActive == true)
        {
            DissolveMaterialEverySecond(Time.deltaTime);
        }
    }

}
