using System;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public PlayerScore playerScore;
    public Action OnScored;

    public void Start()
    {
        OnScored += playerScore.ScorePoint;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnScored.Invoke();
        }
    }
}
