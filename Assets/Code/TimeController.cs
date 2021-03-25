using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public int pregameCountdown;
    public float inGameTimer;
    public GameObject preGameCounterGO;
    public GameObject inGameCounterGO;
    public IEnumerator PregameCountdown(bool isLevelStarted)
    {
        for(int i = 3; i > 0; i--)
        {
            var iterationValue = (i==3 ? pregameCountdown : pregameCountdown -= 1);
            yield return new WaitForSeconds(1.0f);
            preGameCounterGO.GetComponent<TextMeshProUGUI>().text = (pregameCountdown - 1).ToString();
            var text = preGameCounterGO.GetComponent<TextMeshProUGUI>().text;
            Debug.Log("Text is " + text);
        }
        preGameCounterGO.GetComponent<TextMeshProUGUI>().text = "Go!";
        yield return new WaitForSeconds(0.5f);
        preGameCounterGO.SetActive(false);
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.isLevelStarted = true;
    }

    public void LevelTimerCountdown(float time)
    {
        inGameTimer += time;
        float mult = Mathf.Pow(10.0f, (float)2);
        var decimalPoint = Mathf.Round(inGameTimer * mult) / mult;
        inGameCounterGO.GetComponent<TextMeshProUGUI>().text = decimalPoint.ToString();
        var gameManager = FindObjectOfType<GameManager>();
    }

    public IEnumerator GetTimeElapsedSinceRunStart(bool isLevelCompleted, float time)
    {
        if(!isLevelCompleted)
        {
            yield return new WaitForSeconds(time);
            inGameTimer += time;
        }
        yield break;
    }
}
