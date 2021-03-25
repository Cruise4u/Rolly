using System;
using UnityEngine;

public class GUIController : MonoBehaviour,IEventListener<WinEvent>
{
    //Array of GameObjects that have UI elements
    //
    public GameObject[] guiPopUps;

    public void DisplayWinPopup()
    {
        guiPopUps[0].SetActive(true);
    }


    public void ListenToEvent(WinEvent tEvent)
    {
        throw new NotImplementedException();
    }
}
