using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : InteractebleItem
{
    private Inventory ChestInvenotory;
    private bool IsChestOpened = false;

    override protected void Start()
    {
        base.Start();
        ChestInvenotory = gameObject.GetComponent<Inventory>();
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

    public override void UseObj(GameObject interacter)
    {
        if (IsChestOpened)
        {
            interacter.GetComponent<Arm>().CloseInventory();
            IsChestOpened = false;
        }
        else
        {
            interacter.GetComponent<Arm>().OpenInventory(ChestInvenotory);
            IsChestOpened = true;
        }
    }
}
