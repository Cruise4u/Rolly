using System.Collections;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    public string initialMusic;

    public void Start()
    {
        SoundController.Instance.PlayMusic(initialMusic);
    }
}