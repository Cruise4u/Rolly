using System.Collections;
using UnityEngine;

public enum AudioType
{
    Music,
    Sfx,
}

[CreateAssetMenu]
public class SoundPrefab : ScriptableObject
{
    public AudioType audioType;
    public string soundName;
    public AudioClip audioClip;
}
