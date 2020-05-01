using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Arm PlayerArm;
    private bool IsPickUping = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            IsPickUping = true;
        }
        else
        {
            IsPickUping = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (IsPickUping)
        {
            var Item = collision.gameObject;
            if (Item.GetComponent<Item>() != null)
            {
                PlayerArm.PickUpItem(Item);
            }
        }

    }
}
