using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController>
{
    public AudioSource playerAudioSource;
    public List<SoundPrefab> soundPrefabList;
    public Dictionary<string, SoundPrefab> audioDictionary;

    public override void Awake()
    {
        base.Awake();
        audioDictionary = new Dictionary<string, SoundPrefab>();
        AddEntriesToAudioDictionary();
    }

    public void AddEntriesToAudioDictionary()
    {
        foreach(SoundPrefab sound in soundPrefabList)
        {
            audioDictionary.Add(sound.soundName, sound);
        }
    }

    public void PlayMusic(string musicName)
    {
        Debug.Log(audioDictionary[musicName].audioClip);
        playerAudioSource.clip = audioDictionary[musicName].audioClip;
        playerAudioSource.Play();
    }

    public void StopMusic()
    {
        playerAudioSource.Stop();
    }

    public void PlaySound(string soundName)
    {
        playerAudioSource.PlayOneShot(audioDictionary[soundName].audioClip);
    }

    public void StopSound()
    {
        playerAudioSource.Stop();
    }

}
