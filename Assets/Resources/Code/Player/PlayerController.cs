using System;
using System.Collections;
using UnityEngine;

public enum InputType
{
    Desktop,
    Handheld,
}

public class PlayerController : Singleton<PlayerController>,IEventObserver
{
    public InputType inputType;
    public FixedJoystick playerJoystick;
    public bool isInputBlocked;

    public event Action<Vector3> inputDelegate;
    public event Action jumpDelegate;

    //Set values for physics
    //If the value of the virtual joystick it should perform any action
    //It needs to be higher than the "Deadzone" for the virtual joystick
    //It either move or jump
    //
    public void JoystickInput()
    {
        PlayerPhysics.Instance.ballVelocity = new Vector3(playerJoystick.Vertical, 0.0f, -playerJoystick.Horizontal);
    }
    //Call the Jump action from the ball physics
    //
    public void KeyboardAndMouseInput()
    {
        ReadKeyboardInput();
        //ReadMouseInput();
    }
    
    public void ReadKeyboardInput()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                inputDelegate.Invoke(new Vector3(1, 0, 0)); 
                if (Input.GetKey(KeyCode.D))
                {
                    inputDelegate.Invoke(new Vector3(1, 0, -1));
                }
                if (Input.GetKey(KeyCode.A))
                {
                    inputDelegate.Invoke(new Vector3(1, 0, 1));
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputDelegate.Invoke(new Vector3(-1, 0, 0)); 
                if (Input.GetKey(KeyCode.D))
                {
                    inputDelegate.Invoke(new Vector3(-1, 0, -1));
                }
                if (Input.GetKey(KeyCode.A))
                {
                    inputDelegate.Invoke(new Vector3(-1, 0, 1));
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputDelegate.Invoke(new Vector3(0, 0, -1));
                if (Input.GetKey(KeyCode.W))
                {
                    inputDelegate.Invoke(new Vector3(1, 0, -1));
                }
                if (Input.GetKey(KeyCode.S))
                {
                    inputDelegate.Invoke(new Vector3(-1, 0, -1));
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputDelegate.Invoke(new Vector3(0, 0, 1));
                if (Input.GetKey(KeyCode.W))
                {
                    inputDelegate.Invoke(new Vector3(1, 0, 1));
                }
                if (Input.GetKey(KeyCode.S))
                {
                    inputDelegate.Invoke(new Vector3(-1, 0, 1));
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpActionTest();
            }
        }
        else
        {
            inputDelegate.Invoke(new Vector3(0, 0, 0));
        }
    }

    public void ReadMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            JumpActionTest();
        }
        if (Input.GetMouseButtonDown(1))
        {
            BreakActionTest();
        }
    }

    public void JumpActionTest()
    {
        jumpDelegate.Invoke();
    }

    public void BreakActionTest()
    {
        var currentVelocity = PlayerPhysics.Instance.rb.velocity;
        if(currentVelocity.magnitude > 1)
        {
            inputDelegate.Invoke(new Vector3(-currentVelocity.x, 0, -currentVelocity.z) / 5);
        }
    }

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

    public void Start()
    {
        if(GameManager.Instance.playerDeviceType == DeviceType.Handheld)
        {
            inputType = InputType.Handheld;
        }
        else if(GameManager.Instance.playerDeviceType == DeviceType.Desktop)
        {
            inputType = InputType.Desktop;
        }
    }

    public void Update()
    {
        if (isInputBlocked != true)
        {
            switch (inputType)
            {
                case InputType.Handheld:
                    JoystickInput();
                    break;
                case InputType.Desktop:
                    KeyboardAndMouseInput();
                    break;
            }
        }
    }
}
