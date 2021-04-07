using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PrefabSO : ScriptableObject
{
    public List<GameObject> gameObjectList;

    public void LoadObject(GameObject instance,string path)
    {
        instance = Resources.Load<GameObject>(path);
    }

    public GameObject LoadObjectFromList(string path)
    {
        return Resources.Load<GameObject>(path);
    }
}