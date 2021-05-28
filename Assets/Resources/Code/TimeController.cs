using System;
using System.Collections;
using UnityEngine;

public class TimeController : IEventObserver
{
    public int pregameCountdown;
    public float inGameCounter;
    public bool isCountingEverySecond;

    public void StartCountdown()
    {
        StartCoroutine(WaitForCountdownToStart());
    }

    public IEnumerator WaitForCountdownToStart()
    {
        var pregameTimerGO = GUIController.Instance.pregameCounterGO;
        var inGameCounterGO = GUIController.Instance.inGameCounterGO;
        GUIController.Instance.WriteTextDescription(pregameTimerGO, "3");
        pregameCountdown = 3;
        for (int i = 3; i >= 0; i--)
        {
            pregameCountdown -= 1;
            yield return new WaitForSeconds(1.0f);
            GUIController.Instance.ConvertTimeToString(pregameTimerGO, (pregameCountdown));
        }
        GUIController.Instance.WriteTextDescription(pregameTimerGO, "Go!");
        yield return new WaitForSeconds(0.5f);
        pregameTimerGO.SetActive(false);
        isCountingEverySecond = true;
        GameEventManager.Instance.NotifyObserversToEvent(EventName.StartLevel);
    }

    public void CountTimeElapsed(float time)
    {
        var ingameTimerGO = GUIController.Instance.inGameCounterGO;
        inGameCounter += time;
        float decimalPoint = Mathf.Round(inGameCounter);
        GUIController.Instance.ConvertTimeToString(ingameTimerGO,decimalPoint);
    }

    public void StopTimer()
    {
        isCountingEverySecond = false;
    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.StartLevel:
                StartCountdown();
                break;
            default:
                StopTimer();
                break;
        }
    }

}
