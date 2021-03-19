using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public int pregameCountdown;
    public float ingameTimer;
    public GameObject timeToText;

    //public IEnumerator WaitAFewSecondsBeforeStartingGame(bool isLevelStarted)
    //{
    //    yield return new WaitForSeconds(pregameCountdown);
    //    isLevelStarted = true;
    //    Debug.Log("Game started now!");
    //}

    public IEnumerator PregameCountdown(bool isLevelStarted)
    {
        for(int i = 3; i >= 0; i--)
        {
            var iterationValue = (i==3 ? pregameCountdown : pregameCountdown -= 1);
            yield return new WaitForSeconds(1.0f);
            timeToText.GetComponent<TextMeshProUGUI>().text = (pregameCountdown - 1).ToString();
            var text = timeToText.GetComponent<TextMeshProUGUI>().text;
            Debug.Log("Text is " + text);
        }
        timeToText.GetComponent<TextMeshProUGUI>().text = "Go!";
       isLevelStarted = true;
    }

    public IEnumerator GetTimeElapsedSinceRunStart(bool isLevelCompleted, float time)
    {
        if(!isLevelCompleted)
        {
            yield return new WaitForSeconds(time);
            ingameTimer += time;
        }
        yield break;
    }
}
