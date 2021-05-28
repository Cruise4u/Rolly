using System;
using System.Collections;
using UnityEngine;

public class TimeController : MonoBehaviour,IGameEventObserver
{
    public static TimeController instance = null;
    public GUIController guiController;

    public int pregameCountdown;
    public float inGameCounter;

    //public Action StartCountdownDelegate;
    public bool isCountingEverySecond;

    public void StartCountdown()
    {
        StartCoroutine(WaitForCountdownToStart());
    }

    public IEnumerator WaitForCountdownToStart()
    {
        var pregameTimerGO = guiController.pregameCounterGO;
        guiController.WriteTextDescription(pregameTimerGO, "3");
        for (int i = 3; i >= 0; i--)
        {
            pregameCountdown -= 1;
            yield return new WaitForSeconds(1.0f);
            guiController.ConvertTimeToString(pregameTimerGO, (pregameCountdown));
        }
        guiController.WriteTextDescription(pregameTimerGO, "Go!");
        yield return new WaitForSeconds(0.5f);
        pregameTimerGO.SetActive(false);
        isCountingEverySecond = true;
    }

    public void CountTimeElapsed(float time)
    {
        var ingameTimerGO = guiController.inGameCounterGO;
        inGameCounter += time;
        float decimalPoint = Mathf.Round(inGameCounter);
        guiController.ConvertTimeToString(ingameTimerGO,decimalPoint);
    }

    public void EndTimer()
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
                EndTimer();
                break;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isCountingEverySecond != false)
        {
            CountTimeElapsed(Time.deltaTime);
        }
    }
}
