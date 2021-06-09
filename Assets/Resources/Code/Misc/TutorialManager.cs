using System;
using System.Collections;
using UnityEngine;

public class TutorialManager : Singleton<TutorialManager>,IEventObserver
{
    public int phaseCount;
    public GameObject tutorialGUI;
    public GameObject temporaryStarGoal;
    public Transform[] wayPoints;

    public void DisplayTutorialPopUp(string message)
    {
        GUIController.Instance.WriteTextDescription(tutorialGUI,message);
    }

    public IEnumerator TutorialFirstPart(float seconds)
    {
        DisplayTutorialPopUp("Hello There! Nice to meet you!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Let's get started, shall we?");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("To move around here, just use the joystick");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("And point into the direction you want to move in");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("It's pretty simple!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Just give it a try and see if you can reach the star!");
        GUIController.Instance.inputGO.transform.GetChild(0).gameObject.SetActive(true);
        GameEventManager.Instance.NotifyObserversToEvent(EventName.StartLevel);
        SpawnAtPosition(temporaryStarGoal, wayPoints[0]);
        phaseCount += 1;
    }

    public IEnumerator TutorialSecondPart(float seconds)
    {
        DisplayTutorialPopUp("Great Job!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Let's go to the second part!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Move to the next stage. I'll open the gate for you");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("See if you can reach a second star!");
        yield return new WaitForSeconds(seconds);
        SpawnAtPosition(temporaryStarGoal, wayPoints[1]);
        phaseCount += 1;
    }

    public IEnumerator TutorialThirdPart(float seconds)
    {
        PlayerPhysics.Instance.DisablePhysics();
        PlayerController.Instance.BlockInput();
        DisplayTutorialPopUp("Hold on just a second!");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Now we going to learn how to jump and to slow down");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("This will be handy to help with obstacles and avoid you falling on pitfalls");
        yield return new WaitForSeconds(seconds);
        GUIController.Instance.inputGO.transform.GetChild(1).gameObject.SetActive(true);
        GUIController.Instance.inputGO.transform.GetChild(2).gameObject.SetActive(true);
        DisplayTutorialPopUp("Just press the left-button to jump and right-button to break");
        yield return new WaitForSeconds(seconds);
        DisplayTutorialPopUp("Give it a try !");
        yield return new WaitForSeconds(seconds);
        PlayerPhysics.Instance.EnablePhysics();
        PlayerController.Instance.UnblockInput();
    }

    public void SpawnAtPosition(GameObject spawned, Transform transform)
    {
        var instance = Instantiate(spawned);
        instance.transform.position = transform.position;
        instance.tag = "Tutorial";
    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.EnterLevel:
                Debug.Log("Does it work?");
                StartCoroutine(TutorialFirstPart(2.0f));
                break;
            case EventName.Tutorial:
                switch (phaseCount)
                {
                    case 1:
                        StartCoroutine(TutorialSecondPart(2.0f));
                        break;
                    case 2:
                        StartCoroutine(TutorialThirdPart(2.0f));
                        break;
                }
                break;
        }
    }

}
