using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEnabled : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool Clicked;
    public void OnPointerDown(PointerEventData eventData)
    {
        Clicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Clicked = false;
    }
}
