﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class DissolveShaderBehaviour : MonoBehaviour
{
    public float speed = 0.5f;

    private float t = 0.0f;
    private MeshRenderer meshRenderer;
    private Material[] mats;


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
        DissolveEffect();
    }
}