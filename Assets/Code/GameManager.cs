using UnityEngine;
using UnityEngine.SceneManagement;
using Bolt;

public class GameManager : MonoBehaviour
{
    public PlayerController playerControllerReference;
    public bool isGameStarted;


    public void InitializeObjectsConfiguration()
    {
        Variables.Application.Set("gameManagerObject", gameObject);
        Variables.Application.Set("playerControllerObject", playerControllerReference);
    }


    public void Start()
    {
        playerControllerReference.playerDevice = GetPlayerDeviceByType();
    }

    public void Awake()
    {
        InitializeObjectsConfiguration();
    }

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

    public void StartGame()
    {
        isGameStarted = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}