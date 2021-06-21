using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : Singleton<GameManager>,IEventObserver
{
    public List<Gate> gateList;

    public void OpenGate(int id)
    {
        foreach(Gate gate in gateList)
        {
            if(gate.gateID == id)
            {
                StartCoroutine(gate.WaitForSecondsToStartAnimaton(6f));
            }
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.Tutorial:
                OpenGate(0);
                break;
        }
    }
}