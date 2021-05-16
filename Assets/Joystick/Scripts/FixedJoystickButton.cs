using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FixedJoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    protected bool pressed;

    public bool IsJumping => pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        GetComponent<Image>().color = Color.grey;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        GetComponent<Image>().color = Color.white;
    }
}
