using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : interactebleItem
{
    private bool IsOpen = false;
    [SerializeField] private GameObject EndPos;
    [SerializeField] private GameObject InteractbleZone;

    Vector3 startPos;
    Vector3 endPos;

    protected override void Start()
    {
        base.Start();
        endPos = EndPos.transform.position;
        startPos = gameObject.transform.position;
    }

    private void ChangeDoorState()
    {
        if (!IsOpen)
        {
            transform.position = endPos;
            IsOpen = true;
        }
        else
        {           
            transform.position = startPos;
            IsOpen = false;
        }
    }

    public override void UseObj(GameObject interacter)
    {
        ChangeDoorState();
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
