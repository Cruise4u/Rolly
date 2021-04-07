using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour,IGameEventObserver
{
    public PlayerPhysics ballPhysics;
    public FixedJoystick playerJoystick;
    public BreakButton breakButton;
    public bool isInputBlocked;
    public void Init()
    {

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
        if (isInputBlocked != true)
        {
            ballPhysics.Jump();
        }
    }

    public void UnblockInput()
    {
        StartCoroutine(WaitForGameToStartToUnblockInput(3.15f));
    }

    public IEnumerator WaitForGameToStartToUnblockInput(float seconds)
    {
        Debug.Log(isInputBlocked);
        yield return new WaitForSeconds(seconds);
        isInputBlocked = false;
        Debug.Log(isInputBlocked);
    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
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

    //public void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}

    public void Start()
    {
        isInputBlocked = true;
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
        if (isInputBlocked != true)
        {
            JoystickInput();
        }
    }
}
