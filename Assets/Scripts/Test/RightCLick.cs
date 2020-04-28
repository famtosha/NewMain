using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RightCLick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(Input.GetKeyUp(KeyCode.Mouse0)) print("LCKICK");
        if(Input.GetKeyUp(KeyCode.Mouse1)) print("RCLICK");
    }

}
