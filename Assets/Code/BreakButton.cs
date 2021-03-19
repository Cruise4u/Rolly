using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BreakButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerController playerController;

    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.isBreaking = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.isBreaking = false;
    }
}
