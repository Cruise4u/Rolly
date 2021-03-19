using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BreakButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerController playerController;

    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.ballPhysics.isBreaking = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.ballPhysics.isBreaking = false;
    }
}
