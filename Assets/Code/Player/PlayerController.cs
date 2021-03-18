using Michsky.UI.ModernUIPack;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BallPhysics ballPhysics;
    public FixedJoystick playerJoystick;


    public DeviceType playerDevice;

    public void InitializeController() 
    {
        //ballPhysics.SetPhysicsValue();
    }

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

    public void JumpButton()
    {
        ballPhysics.Jump();
    }

    public void FixedUpdate()
    {
        if(playerDevice == DeviceType.Desktop)
        {
            KeyboardInput();
        }
        else if (playerDevice == DeviceType.Handheld)
        {
            JoystickInput();
        }
    }
}


