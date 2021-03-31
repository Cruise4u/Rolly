using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIController : MonoBehaviour,IGameEventObserver
{
    //Array of GameObjects that have UI elements
    //
    public GameObject parentPopup;
    public GameObject[] guiPopUps;

    public void DisplayWinPopup()
    {
        parentPopup.SetActive(true);
        guiPopUps[0].SetActive(true);
    }

    public void DisplayLosePopup()
    {
        parentPopup.SetActive(true);
        guiPopUps[1].SetActive(true);
    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.Win:
                DisplayWinPopup();
                break;
            case EventName.Lose:
                DisplayLosePopup();
                break;
        }
    }
}
