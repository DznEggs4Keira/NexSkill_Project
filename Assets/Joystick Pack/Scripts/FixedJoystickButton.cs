using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FixedJoystickButton : Joystick
{
    protected bool pressed;

    public override void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        GetComponent<Image>().color = Color.grey;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        GetComponent<Image>().color = Color.white;
    }
}
