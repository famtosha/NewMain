using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : interactebleItem
{
    private bool IsOpen = false;
    private float State = 0;
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

    private void Update()
    {
        if (IsOpen)
        {
            State += 0.1f;
        }
        else
        {
            State -= 0.1f;
        }
        State = Mathf.Clamp(State, 0, 1);
        transform.position = Vector3.Lerp(startPos, endPos,State);
    }

    private void ChangeDoorState()
    {
        if (!IsOpen)
        {
            IsOpen = true;
        }
        else
        {           
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
