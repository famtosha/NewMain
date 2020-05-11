using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public List<Inventory> inventorys;
    public AnotherUI anotherUI;

    public bool IsAnyChestOpened = false;

    public void OpenInventory(Inventory inventory)
    {
        anotherUI.OpenInventory(inventory);
        inventory.gameObject.GetComponent<Chest>().User = gameObject.GetComponent<Arm>();
        IsAnyChestOpened = true;
    }

    public void CloseInventory()
    {
        anotherUI.CloseInvenotory();
        IsAnyChestOpened = false;
    }

    public void PickUpItem(GameObject Item)
    {
        foreach (var inv in inventorys)
        {
            Item.SetActive(false);
            if (inv.AddToFreeSlot(Item))
            {
                Item.transform.SetParent(gameObject.transform);
                return;
            }
            else
            {
                Item.SetActive(true);
            }
        }    
    }

    public void DropItem(GameObject Item)
    {
        if (Item == null) return;
        Item.SetActive(true);
        Item.transform.SetParent(null);
        Item.transform.Translate(2, 0, 0);
    }
}
