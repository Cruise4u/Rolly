using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour,IGameEventObserver
{
    public int pregameCountdown;
    public GameObject preGameCounterGO;

    public float inGameCounter;
    public GameObject inGameCounterGO;

    //public Action StartCountdownDelegate;
    public bool isCountingEverySecond;

    public void StartCountdown()
    {
        StartCoroutine(WaitForCountdownToStart());
    }

    public IEnumerator WaitForCountdownToStart()
    {
        for (int i = 3; i > 0; i--)
        {
            var iterationValue = (i == 3 ? pregameCountdown : pregameCountdown -= 1);
            yield return new WaitForSeconds(1.0f);
            preGameCounterGO.GetComponent<TextMeshProUGUI>().text = (pregameCountdown - 1).ToString();
            var text = preGameCounterGO.GetComponent<TextMeshProUGUI>().text;
            Debug.Log("Text is " + text);
        }
        preGameCounterGO.GetComponent<TextMeshProUGUI>().text = "Go!";
        yield return new WaitForSeconds(0.5f);
        preGameCounterGO.SetActive(false);
        isCountingEverySecond = true;
    }

    public void CountTimeElapsed(float time)
    {
        inGameCounter += time;
        float decimalPoint = Mathf.Round(inGameCounter);
        SetTimerAsString(decimalPoint);
    }

    public void SetTimerAsString(float timer)
    {
        inGameCounterGO.GetComponent<TextMeshProUGUI>().text = timer.ToString();
    }

    public void EndTimer()
    {
        isCountingEverySecond = false;
    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.Start:
                StartCountdown();
                break;
            case EventName.End:
                EndTimer();
                break;
        }
    }

    public void Update()
    {
        if (isCountingEverySecond != false)
        {
            CountTimeElapsed(Time.deltaTime);
        }
    }
}
