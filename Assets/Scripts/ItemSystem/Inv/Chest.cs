using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Inventory ChestInv;
    public Arm PlayerArm;
    private Transform PlayerTransform;
    private bool IsInvOpen = false;

    private void Start()
    {
        PlayerTransform = PlayerArm.gameObject.transform;
    }

    private void OnMouseUp()
    {
        if (IsInvOpen)
        {
            PlayerArm.CloseInventory();
            IsInvOpen = false;
        }
        else if (Vector3.Distance(PlayerTransform.position, gameObject.transform.position) < 2)
        {
            if (!PlayerArm.IsAnyChestOpened)
            {
                PlayerArm.OpenInventory(ChestInv);
                IsInvOpen = true;
            }
        }
    }

    private void Update()
    {
        if (IsInvOpen)
        {
            if(Vector3.Distance(PlayerTransform.position, gameObject.transform.position) > 2)
            {
                PlayerArm.CloseInventory();
                IsInvOpen = false;
            }
        }
    }
}
