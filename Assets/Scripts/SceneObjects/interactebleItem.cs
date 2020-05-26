using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class InteractebleItem : MonoBehaviour
{
    protected TextMesh textMesh;

    protected virtual void Start()
    {
        textMesh = gameObject.GetComponentInChildren<TextMesh>();
    }

    public virtual void UseObj(GameObject interacter)
    {

    }

    public virtual void TouchObj(bool thing)
    {

    }
}
