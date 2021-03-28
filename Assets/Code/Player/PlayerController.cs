using Michsky.UI.ModernUIPack;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public BallPhysics ballPhysics;
    public FixedJoystick playerJoystick;


    public bool isInputBlocked;
    public Action BlockInputDelegate;

    public void Init()
    {
        BlockInputDelegate += BlockInput;
    }

    // Set values for physics
    //If the value of the virtual joystick it should perform any action
    //It needs to be higher than the "Deadzone" for the virtual joystick
    //It either move or jump
    public void JoystickInput()
    {
        ballPhysics.ballDirection = new Vector3(playerJoystick.Vertical, 0.0f, -playerJoystick.Horizontal);
    }

    public void BlockInput()
    {
        isInputBlocked = true;
    }

    //Call the Jump action from the ball physics
    //
    public void JumpButton()
    {
        ballPhysics.Jump();
    }

    public void OnEnable()
    {
        BlockInputDelegate += BlockInput;
    }

    public void OnDisable()
    {
        BlockInputDelegate -= BlockInput;
    }

    public void Update()
    {
        #region Input By Device
        //if (gameManager.playerDeviceType == DeviceType.Desktop)
        //{
        //    JoystickInput();
        //    //KeyboardInput();
        //    if (ballPhysics.isBreaking == true)
        //    {
        //        ballPhysics.BreakMove();
        //    }
        //}
        //else if (gameManager.playerDeviceType == DeviceType.Handheld)
        //{
        //    JoystickInput();
        //    if (ballPhysics.isBreaking == true)
        //    {
        //        ballPhysics.BreakMove();
        //    }
        //}
        #endregion
        if (isInputBlocked == false)
        {
            JoystickInput();
            if (ballPhysics.isBreaking == true)
            {
                ballPhysics.BreakMove();
            }
        }
    }

}
