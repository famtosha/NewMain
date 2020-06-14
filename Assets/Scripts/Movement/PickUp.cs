using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Arm PlayerArm;
    private bool IsPickUping = false;

    private void Start()
    {
        PlayerArm = transform.GetComponentInParent<Arm>();
    }

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
