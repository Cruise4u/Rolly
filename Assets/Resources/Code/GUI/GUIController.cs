using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIController : Singleton<GUIController>, IGameEventObserver
{
    public GameObject pregameCounterGO;
    public GameObject inGameCounterGO;
    public GameObject winPopupGO;
    public GameObject losePopupGO;
    public GameObject InputGUIGO;

    public void DisplayWinPopup()
    {
        winPopupGO.SetActive(true);
    }

    public void DisplayLosePopup()
    {
        losePopupGO.SetActive(true);
    }

    public void ResetPopups()
    {
        winPopupGO.SetActive(false);
        losePopupGO.SetActive(false);
    }

    public void ConvertTimeToString(GameObject gui,float timer)
    {
        gui.GetComponent<TextMeshProUGUI>().text = timer.ToString();
    }

    public void WriteTextDescription(GameObject gui,string message)
    {
        gui.GetComponent<TextMeshProUGUI>().text = message;
    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.StartLevel:
                pregameCounterGO.SetActive(true);
                break;
            case EventName.Win:
                DisplayWinPopup();
                break;
            case EventName.Lose:
                DisplayLosePopup();
                break;
        }
    }

}

