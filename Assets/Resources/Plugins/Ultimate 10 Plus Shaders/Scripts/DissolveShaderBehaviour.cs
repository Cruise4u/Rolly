using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class DissolveShaderBehaviour : Singleton<DissolveShaderBehaviour>
{
    public float speed = 0.5f;
    public float t = 0.0f;
    private MeshRenderer meshRenderer;
    private Material[] mats;

    public bool isShaderActive;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        mats = meshRenderer.materials;
    }

    public void ResetEffect()
    {
        mats[0].SetFloat("_Cutoff", 0);
        meshRenderer.materials = mats;
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

}
