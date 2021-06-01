using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour,IEventObserver
{
    public FixedJoystick playerJoystick;
    public BreakButton breakButton;
    public bool isInputBlocked;
    RaycastHit hit;

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
    public void JumpAction()
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
    public void CheckIfIsAboveGround()
    {
        var bottomPosition = Vector3.down * 3.0f;
        if (Physics.Raycast(gameObject.transform.position, bottomPosition, out hit, 1.0f))
        {
            if (hit.collider.gameObject.CompareTag("Jump"))
            {
                PlayerPhysics.Instance.isInAir = false;
            }
        }
    }
    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.EnterLevel:
                BlockInput();
                break;
            case EventName.StartLevel:
                Debug.Log("Unblocking Input!");
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

    public void Update()
    {
        if(isInputBlocked != true)
        {
            JoystickAction();
        }
    }
}
