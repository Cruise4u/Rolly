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

    public GameObject scoreUIStarParent;
    public Sprite fullStar;

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

    public void AttributeStarToScoreUI(int number)
    {
        if (number == 1)
        {
            var parent = scoreUIStarParent.transform.GetChild(0);
            ChangeStarSprite(parent.GetChild(0).gameObject);
        }
        else if (number == 2)
        {
            var parent = scoreUIStarParent.transform.GetChild(1);
            ChangeStarSprite(parent.GetChild(0).gameObject);
            ChangeStarSprite(parent.GetChild(1).gameObject);
        }
        else if (number == 3)
        {
            var parent = scoreUIStarParent.transform.GetChild(2);
            ChangeStarSprite(parent.GetChild(0).gameObject);
            ChangeStarSprite(parent.GetChild(1).gameObject);
            ChangeStarSprite(parent.GetChild(2).gameObject);
        }
    }

    public void ChangeStarSprite(GameObject starUIGO)
    {
        starUIGO.GetComponent<Image>().sprite = fullStar;
    }

    public void SetScoreGoalForEachStar()
    {
        if(scoreUIStarParent != null)
        {
            for (int i = 0; i < 3; i++)
            {
                var parent = scoreUIStarParent.transform.GetChild(i);
                var lastChild = parent.childCount;
                Debug.Log(parent.GetChild(lastChild - 1).gameObject);
                WriteTextDescription(parent.GetChild(lastChild - 1).gameObject, LevelManager.Instance.currentLevelData.scoreGoalArray[i].ToString());
            }
        }
        Debug.Log("Nothing Happened!");
    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.EnterLevel:
                SetScoreGoalForEachStar();
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
