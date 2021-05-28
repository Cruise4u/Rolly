using UnityEngine;
using UnityEngine.SceneManagement;
using Bolt;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    public Dictionary<EventName, GameEvent> gameEventDictionary;
    public void Init()
    {
        gameEventDictionary = new Dictionary<EventName, GameEvent>();
        GameEvent[] gameEvents = Resources.LoadAll<GameEvent>("Prefabs/Events");
        foreach (GameEvent gameEvent in gameEvents)
        {
            if (!gameEventDictionary.ContainsKey(gameEvent.eventName))
            {
                gameEventDictionary.Add(gameEvent.eventName, gameEvent);
            }
        }
    }




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
        Debug.Log(EventManager.Instance);
        EventManager.Instance.NotifyObserversToEvent(EventName.EnterLevel);
    }

}

