using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    private Canvas canvas;

    public bool isPanelEnable => canvas.enabled;

    private void Awake()
    {
        canvas = gameObject.GetComponent<Canvas>();
    }

    public void DisablePanel()
    {
        canvas.enabled = false;
    }

    public void EnablePanel()
    {
        canvas.enabled = true;
    }

    public void ChangePanelState()
    {
        canvas.enabled = !canvas.enabled;
    }
}