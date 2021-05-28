using UnityEngine;
using UnityEngine.SceneManagement;
using Bolt;

public class GameManager : MonoBehaviour
{
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

    public void Start()
    {
        if(playerDeviceType == DeviceType.Handheld)
        {
            Screen.orientation = playerDeviceOrientation;
        }
    }
}

