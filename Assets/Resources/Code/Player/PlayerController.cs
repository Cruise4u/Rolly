using System;
using System.Collections;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>,IEventObserver
{
    public FixedJoystick playerJoystick;
    public bool isInputBlocked;

    //Set values for physics
    //If the value of the virtual joystick it should perform any action
    //It needs to be higher than the "Deadzone" for the virtual joystick
    //It either move or jump
    //
    public void JoystickAction()
    {
        PlayerPhysics.Instance.ballDirection = new Vector3(playerJoystick.Vertical, 0.0f, -playerJoystick.Horizontal);
    }
    //Call the Jump action from the ball physics
    //

    public void BreakAction()
    {
        if (isInputBlocked != true)
        {
            GameEventManager.Instance.NotifyObserversToEvent(EventName.StartBreaking);
        }
    }

    public void JumpAction()
    {
        if (isInputBlocked != true && PlayerPhysics.Instance.numberJumps > 0)
        {
            GameEventManager.Instance.NotifyObserversToEvent(EventName.StartJumping);
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
            case EventName.Tutorial:
                UnblockInput();
                break;
        }
    }
    public void Update()
    {
        if(isInputBlocked != true)
        {
            JoystickAction();
        }
    }
}
