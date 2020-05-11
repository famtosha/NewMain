using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Inventory ChestInv;
    public Arm User;

    private Transform PlayerTransform => User.gameObject.transform;
    private bool IsInvOpen = false;

    private void OnMouseUp()
    {
        if (IsInvOpen)
        {
            User.CloseInventory();
            IsInvOpen = false;
        }
        else if (Vector3.Distance(PlayerTransform.position, gameObject.transform.position) < 2)
        {
            if (!User.IsAnyChestOpened)
            {
                User.OpenInventory(ChestInv);
                IsInvOpen = true;
            }
        }
    }

    private void Update()
    {
        if (IsInvOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                User.CloseInventory();
                IsInvOpen = false;
                return;
            }

            if(Vector3.Distance(PlayerTransform.position, gameObject.transform.position) > 2)
            {
                User.CloseInventory();
                IsInvOpen = false;
            }
        }
    }
}
