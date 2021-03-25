using Michsky.UI.ModernUIPack;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour,IEventListener<WinEvent>
{
    // References to physics and joystick controller objects
    public GameManager gameManager;
    public BallPhysics ballPhysics;
    public FixedJoystick playerJoystick;
    public bool isInputBlocked;

    public Action BlockInputDelegate;

    public void Init()
    {
        BlockInputDelegate += BlockInput;
    }

    public void BlockInput()
    {
        isInputBlocked = true;
    }

    // Set values for physics
    public void InitializeController()
    {
        //ballPhysics.SetPhysicsValue();
    }

    //If the value of the virtual joystick it should perform any action
    //It needs to be higher than the "Deadzone" for the virtual joystick
    //It either move or jump
    public void JoystickInput()
    {
        ballPhysics.ballDirection = new Vector3(playerJoystick.Vertical, 0.0f, -playerJoystick.Horizontal);
    }

    //Call the Jump action from the ball physics
    //
    public void JumpButton()
    {
        ballPhysics.Jump();
    }

    //Load the scene from SceneManager in GameManager object
    //
    public void RestartLevelButton()
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.RestartLevel();
    }

    public void Start()
    {
        if (gameManager.playerDeviceType == DeviceType.Handheld)
        {
            Screen.orientation = gameManager.playerDeviceOrientation;
        }
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
        if(gameManager.isLevelStarted == true)
        {
            if(isInputBlocked == false)
            {
                JoystickInput();
                if (ballPhysics.isBreaking == true)
                {
                    ballPhysics.BreakMove();
                }
            }
        }
    }

    public void ListenToEvent(WinEvent tEvent)
    {
        tEvent.winDelegateAction += BlockInputDelegate;
    }

}
