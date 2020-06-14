using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ButtonController : InteractebleItem
{
    [SerializeField] private List<Light2D> LightList = new List<Light2D>();
    private bool IsLightActive = false;

    public override void UseObj(GameObject interacter)
    {
        base.UseObj(interacter);
        if (!IsLightActive)
        {
            ChangeLightState(true);
        }
        else
        {
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
            textMesh.text = "E";
        }
        else
        {
            textMesh.text = "";
        }
    }
}