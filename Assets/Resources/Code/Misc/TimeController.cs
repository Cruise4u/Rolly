using System;
using System.Collections;
using UnityEngine;

public class TimeController
{
    public int pregameCountdown;
    public float inGameCounter;
    public bool isCountingEverySecond;

    public TimeController()
    {

    }

    public void StopTimer()
    {
        isCountingEverySecond = false;
    }

    public void ResetTimer()
    {
        var inGameCounterGO = GUIController.Instance.inGameCounterGO;
        var pregameCounterGO = GUIController.Instance.pregameCounterGO;
        pregameCounterGO.SetActive(false);
        inGameCounterGO.SetActive(false);
        inGameCounter = 0;
    }

    public void CountdownElapsedTime(GameObject timer,float time)
    {
        inGameCounter += time;
        float decimalPoint = Mathf.Round(inGameCounter);
        GUIController.Instance.ConvertTimeToString(GUIController.Instance.inGameCounterGO, decimalPoint);
    }

    public IEnumerator WaitForCountdownToStart()
    {
        var inGameCounterGO = GUIController.Instance.inGameCounterGO;
        var pregameCounterGO = GUIController.Instance.pregameCounterGO;
        pregameCounterGO.SetActive(true);
        GUIController.Instance.WriteTextDescription(pregameCounterGO, "3");
        pregameCountdown = 3;
        for (int i = 3; i > 0; i--)
        {
            pregameCountdown -= 1;
            yield return new WaitForSeconds(1.0f);
            GUIController.Instance.ConvertTimeToString(pregameCounterGO, pregameCountdown);
        }
        GUIController.Instance.WriteTextDescription(pregameCounterGO, "Go!");
        yield return new WaitForSeconds(0.1f);
        pregameCounterGO.SetActive(false);
        inGameCounterGO.SetActive(true);
        GUIController.Instance.InputGUIGO.SetActive(true);
        isCountingEverySecond = true;
        EventManager.Instance.NotifyObserversToEvent(EventName.StartLevel);
    }

}
