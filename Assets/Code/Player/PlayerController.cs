using Michsky.UI.ModernUIPack;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // References to physics and joystick controller objects
    public GameManager gameManager;
    public BallPhysics ballPhysics;
    public FixedJoystick playerJoystick;
    public bool isInputBlocked;





    // Set values for physics
    public void InitializeController()
    {
        //ballPhysics.SetPhysicsValue();
    }

    //Check if a key was pressed and what action to trigger depending on the input
    //It either move or jump
    public void KeyboardInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ballPhysics.Move(Vector3.right, 1.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            ballPhysics.Move(Vector3.right, -1.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ballPhysics.Move(Vector3.forward, -1.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            ballPhysics.Move(Vector3.forward, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpButton();
        }
    }

    //If the value of the virtual joystick it should perform any action
    //It needs to be higher than the "Deadzone" for the virtual joystick
    //It either move or jump
    public void JoystickInput()
    {
        if (playerJoystick.Horizontal > 0.1f)
        {
            ballPhysics.Move(Vector3.forward, -1.0f);
        }
        if (playerJoystick.Horizontal < -0.1f)
        {
            ballPhysics.Move(Vector3.forward, 1.0f);
        }
        if (playerJoystick.Vertical > 0.1f)
        {
            ballPhysics.Move(Vector3.right, 1.0f);
        }
        if (playerJoystick.Vertical < -0.1f)
        {
            ballPhysics.Move(Vector3.right, -1.0f);
        }

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

    }

    //Every timestep(x times per frame)
    //Check the virtual joystick input
    public void FixedUpdate()
    {
        if(gameManager.playerDeviceType == DeviceType.Desktop)
        {
            KeyboardInput();
            if (ballPhysics.isBreaking == true)
            {
                ballPhysics.BreakMove();
            }
        }
        else if (gameManager.playerDeviceType == DeviceType.Handheld)
        {
            Screen.orientation = gameManager.playerDeviceOrientation;
            JoystickInput();
            if(ballPhysics.isBreaking == true)
            {
                ballPhysics.BreakMove();
            }
        }
    }

    public void Update()
    {
        
    }
}