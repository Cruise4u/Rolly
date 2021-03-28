using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCamera playerCamera;
    public PlayerScore playerScore;
    public PlayerController playerController;
    public GUIController guiController;


}

public enum TagEnum
{
    Ground,
    Win,
    Defeat,
}