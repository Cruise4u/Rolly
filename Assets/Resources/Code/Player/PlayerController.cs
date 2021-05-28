using System;
using System.Collections;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>,IGameEventObserver
{
    public GameObject playerBase;
    public FixedJoystick playerJoystick;
    private bool isInputBlocked;
    public void SpawnPlayerOnBase(LevelData levelData)
    {
        gameObject.transform.position = levelData.sceneBase.transform.position;
    }
    public void JoystickInput()
    {
        PlayerPhysics.Instance.ballDirection = new Vector3(playerJoystick.Vertical, 0.0f, -playerJoystick.Horizontal);
    }
    //Call the Jump action from the ball physics
    //
    public void JumpButton()
    {
        if (isInputBlocked != true)
        {
            PlayerPhysics.Instance.Jump();
        }
    }
    public void BlockInput()
    {
        isInputBlocked = true;
    }
    public void UnblockInput()
    {
        isInputBlocked = false;
    }
    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.EnterLevel:
                BlockInput();
                break;
            case EventName.StartLevel:
                UnblockInput();
                break;
            case EventName.EndLevel:
                BlockInput();
                break;
            case EventName.Win:
                BlockInput();
                break;
            case EventName.Lose:
                BlockInput();
                break;
        }
    }
    public IEnumerator WaitForGameToStartToUnblockInput(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isInputBlocked = false;
    }

    public void Update()
    {
        if (isInputBlocked != true)
        {
            JoystickInput();
        }
    }
}
