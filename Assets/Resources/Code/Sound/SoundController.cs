using System;
using System.Collections.Generic;
using UnityEngine;

public enum SoundName
{
    AcceptUISound,
    DeclineUISound,
    WinSound,
    LoseSound,
    CountdownSound,
    StartSound,
    BurnSound,
    JumpSound,
}

public class SoundController : Singleton<SoundController>,IEventObserver
{
    public AudioSource playerMusicSource;
    public AudioSource playerSfxSource;
    public List<SoundPrefab> soundPrefabList;

    public Dictionary<string, SoundPrefab> musicSourceDictionary;
    public Dictionary<string, SoundPrefab> sfxSourceDictionary;

    public override void Awake()
    {
        base.Awake();
        musicSourceDictionary = new Dictionary<string, SoundPrefab>();
        sfxSourceDictionary = new Dictionary<string, SoundPrefab>();
        AddEntriesToAudioDictionary();
    }

    public void AddEntriesToAudioDictionary()
    {
        foreach(SoundPrefab sound in soundPrefabList)
        {
            if(sound.audioType == AudioType.Music)
            {
                musicSourceDictionary.Add(sound.soundName, sound);
            }
            else
            {
                sfxSourceDictionary.Add(sound.soundName, sound);
            }
        }
    }

    public void PlayMusic(string musicName)
    {
        playerMusicSource.clip = musicSourceDictionary[musicName].audioClip;
        playerMusicSource.Play();
    }

    public void StopMusic()
    {
        playerMusicSource.Stop();
    }

    public void PlaySound(string soundName)
    {
        if(!playerSfxSource.isPlaying)
        {
            playerSfxSource.PlayOneShot(sfxSourceDictionary[soundName].audioClip);
        }
    }

    public void StopAllSoundSources()
    {
        playerMusicSource.Stop();
        playerSfxSource.Stop();
    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.Win:
                PlaySound("WinSound");
                break;
            case EventName.Lose:
                PlaySound("LoseSound");
                StopMusic();
                break;
            case EventName.EnterLevel:
                PlayMusic(LevelManager.Instance.currentLevelName.ToString());
                break;
        }
    }
}
