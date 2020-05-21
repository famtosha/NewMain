using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class interactebleItem : MonoBehaviour
{
    protected TextMesh textMesh;

    protected void Start()
    {
        textMesh = gameObject.GetComponent<TextMesh>();
    }

    public virtual void UseObj()
    {

    }

    public virtual void TouchObj(bool thing)
    {

    }
}
