using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class ButtonCont : interactebleItem
{
    [SerializeField] List<Light2D> LightList = new List<Light2D>();

    private bool IsLightActive = false;

    public override void UseObj(GameObject interacter)
    {
        if (!IsLightActive)
        {
            ChangeLightState(true);          
            print("turn on light");
        }
        else
        {
            print("turn off light");
            ChangeLightState(false);
        }
    }

    private void ChangeLightState(bool state)
    {
        foreach (Light2D light in LightList)
        {
            light.enabled = state;
        }
        IsLightActive = state;
    }

    public override void TouchObj(bool thing)
    {
        if (thing)
        {
            textMesh.text = "B";
        }
        else
        {
            textMesh.text = "";
        }
    }
}
