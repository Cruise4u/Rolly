using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIController : Singleton<GUIController>,IEventObserver
{
    //Array of GameObjects that have UI elements
    //
    public PrefabSO counterPrefab;
    public GameObject parentPopup;
    public GameObject[] guiPopUps;
    public GameObject pregameCounterGO;
    public GameObject inGameCounterGO;
    public GameObject inputGO;

    string pregameCounterPath = "Prefabs/Canvases/PreGameCountdown";
    string ingameCounterPath = "Prefabs/Canvases/IngameCountdown";

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
            case EventName.Win:
                DisplayWinPopup();
                break;
            case EventName.Lose:
                DisplayLosePopup();
                break;
        }
    }

    public override void Awake()
    {
        base.Awake();
        counterPrefab.LoadObject(pregameCounterGO, pregameCounterPath);
        counterPrefab.LoadObject(inGameCounterGO, ingameCounterPath);
    }
}
