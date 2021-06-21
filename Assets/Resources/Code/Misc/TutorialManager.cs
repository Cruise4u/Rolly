using System;
using System.Collections;
using UnityEngine;

public enum TutorialType
{
    Handheld,
    Desktop,
}

public class TutorialManager : Singleton<TutorialManager>,IEventObserver
{
    public int phaseCount;
    public GameObject tutorialText;
    public GameObject temporaryStarGoal;
    public Transform[] wayPoints;
    TutorialType tutorialType;
    public void DisplayTutorialPopUp(string message)
    {
        GUIController.Instance.WriteTextDescription(tutorialText, message);
    }
    public void SpawnAtPosition(GameObject spawned, Transform transform)
    {
        var instance = Instantiate(spawned);
        instance.transform.position = transform.position;
        instance.tag = "Tutorial";
    }

    public void SetTutorialByDeviceType()
    {
        if (GameManager.Instance.playerDeviceType == DeviceType.Desktop)
        {
            tutorialType = TutorialType.Desktop;
        }
        else if (GameManager.Instance.playerDeviceType == DeviceType.Handheld)
        {
            tutorialType = TutorialType.Handheld;
        }
    }

    #region Tutorial Dialogue First Part
    public void DisplayFirstPartTutorial(float seconds)
    {
        if (tutorialType == TutorialType.Desktop)
        {
            StartCoroutine(DisplayDesktopTutorialFirstMessage(seconds));
        }
        else
        {
            StartCoroutine(DisplayHandheldTutorialFirstMessage(seconds));
        }
        SpawnAtPosition(temporaryStarGoal, wayPoints[0]);
    }

    public IEnumerator DisplayDesktopTutorialFirstMessage(float seconds)
    {
        DisplayTutorialPopUp("Hello There! Nice to meet you!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Let's get started, shall we?");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Try to move around using the WASD");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Just give it a try and see if you can reach the star!");
        GameEventManager.Instance.NotifyObserversToEvent(EventName.StartLevel);
    }

    public IEnumerator DisplayHandheldTutorialFirstMessage(float seconds)
    {
        DisplayTutorialPopUp("Hello There! Nice to meet you!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Let's get started, shall we?");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("To move around here, just use the joystick");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("And point into the direction you want to move in");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Just give it a try and see if you can reach the star!");
        GUIController.Instance.inputGO.transform.GetChild(0).gameObject.SetActive(true);
        GameEventManager.Instance.NotifyObserversToEvent(EventName.StartLevel);
    }
    #endregion

    #region Tutorial Dialogue Second Part

    public void DisplaySecondPartTutorial(float seconds)
    {
        if (tutorialType == TutorialType.Desktop)
        {
            StartCoroutine(DisplayDesktopTutorialSecondMessage(seconds));
        }
        else
        {
            StartCoroutine(DisplayHandheldTutorialSecondMessage(seconds));
        }
        SpawnAtPosition(temporaryStarGoal, wayPoints[1]);
    }

    public IEnumerator DisplayDesktopTutorialSecondMessage(float seconds)
    {
        DisplayTutorialPopUp("Great Job!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Let's go to the second part!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Move to the next stage. I'll open the gate for you");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("See if you can reach a second star!");
        yield return new WaitForSeconds(seconds);
    }

    public IEnumerator DisplayHandheldTutorialSecondMessage(float seconds)
    {
        DisplayTutorialPopUp("Great Job!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Let's go to the second part!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Move to the next stage. I'll open the gate for you");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("See if you can reach a second star!");
        yield return new WaitForSeconds(seconds);
    }
    #endregion

    #region Tutorial Dialogue Third Part

    public void DisplayThirdPartTutorial(float seconds)
    {
        if (tutorialType == TutorialType.Desktop)
        {
            StartCoroutine(DisplayDesktopTutorialThirdMessage(seconds));
        }
        else
        {
            StartCoroutine(DisplayHandheldTutorialThirdMessage(seconds));
        }
        SpawnAtPosition(temporaryStarGoal, wayPoints[2]);
        phaseCount += 1;
    }

    public IEnumerator DisplayDesktopTutorialThirdMessage(float seconds)
    {
        PlayerPhysics.Instance.DisablePhysics();
        PlayerController.Instance.BlockInput();
        DisplayTutorialPopUp("Hold on just a second!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("That orange thing.. is lava");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("You know lava right? Try not to touch it !");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("You can jump over it and try to make sure you can land on the ground");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Just press the left-mouse button to jump and try to reach the other side!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Good luck!");
        PlayerPhysics.Instance.EnablePhysics();
        PlayerController.Instance.UnblockInput();
    }

    public IEnumerator DisplayHandheldTutorialThirdMessage(float seconds)
    {
        PlayerPhysics.Instance.DisablePhysics();
        PlayerController.Instance.BlockInput();
        DisplayTutorialPopUp("Hold on just a second!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("That orange thing.. is lava");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("You know lava right? Try not to touch it !");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("You can jump over it and try to make sure you can land on the ground");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Just press the left-button to jump!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Give it a try !");
        GUIController.Instance.inputGO.transform.GetChild(1).gameObject.SetActive(true);
        PlayerPhysics.Instance.EnablePhysics();
        PlayerController.Instance.UnblockInput();
    }
    #endregion

    #region Tutorial Fail Part

    public void DisplayLastPartFailTutorial(float seconds)
    {
        StartCoroutine(TutorialFailPart(seconds));
        LevelManager.Instance.SpawnPlayer(LevelManager.Instance.levelSpawner);
    }

    public IEnumerator TutorialFailPart(float seconds)
    {
        PlayerPhysics.Instance.DisablePhysics();
        PlayerController.Instance.BlockInput();
        DisplayTutorialPopUp("It's okey! Try again! This time you'll manage!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Try to time it before jumping");
        yield return new WaitForSeconds(seconds);
    }

    #endregion

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.EnterLevel:
                SetTutorialByDeviceType();
                DisplayFirstPartTutorial(2);
                break;
            case EventName.Tutorial:
                phaseCount += 1;
                switch (phaseCount)
                {
                    case 1:
                        DisplaySecondPartTutorial(2);
                        break;
                    case 2:
                        DisplayThirdPartTutorial(2);
                        break;
                }
                break;
            case EventName.Lose:
                DisplayLastPartFailTutorial(2.0f);
                break;
        }
    }

}
