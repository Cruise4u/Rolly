using UnityEngine;

public class GameManager : Singleton<GameManager>,IEventObserver
{
    //Reference to device type being used
    //For example, is a mobile phone or a PC?
    public DeviceType playerDeviceType;
    private ScreenOrientation playerDeviceOrientation;

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

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.EnterLevel:
                playerDeviceType = GetPlayerDeviceByType();
                break;
        }
    }
}

