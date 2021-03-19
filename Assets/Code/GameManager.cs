using UnityEngine;
using UnityEngine.SceneManagement;
using Bolt;

public class GameManager : MonoBehaviour
{
    public TimeController timeController;
    public PlayerController playerControllerReference;
    public bool isLevelStarted;
    public bool isLevelFinished;

    //Reference to device type being used
    //For example, is a mobile phone or a PC?
    public DeviceType playerDeviceType;
    public ScreenOrientation playerDeviceOrientation;

    public DeviceType GetPlayerDeviceByType()
    {
        DeviceType currentDevice = DeviceType.Unknown;
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            currentDevice = DeviceType.Desktop;
        }
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            currentDevice = DeviceType.Handheld;
        }
        return currentDevice;
    }

    public void InitializeObjectsConfiguration()
    {
        Variables.Application.Set("gameManagerObject", gameObject);
        Variables.Application.Set("playerControllerObject", playerControllerReference);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Start()
    {
        playerDeviceType = GetPlayerDeviceByType();
        timeController.StartCoroutine(timeController.PregameCountdown(isLevelStarted));
    }

    public void Awake()
    {
        InitializeObjectsConfiguration();
    }


}