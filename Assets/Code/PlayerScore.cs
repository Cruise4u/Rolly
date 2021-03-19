using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score;



    public void ScorePoint()
    {
        Debug.Log("You scored a point! You rock!");
    }
}