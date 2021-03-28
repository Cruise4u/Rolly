using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIController : MonoBehaviour,IGameEventObserver
{
    //Array of GameObjects that have UI elements
    //
    public GameObject[] guiPopUps;

    public void DisplayWinPopup()
    {
        guiPopUps[0].SetActive(true);
    }

    public void DisplayLosePopup()
    {
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
