using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public List<Inventory> inventorys;
    private AnotherUI anotherUI;

    public bool IsAnyChestOpened = false;

    private void Start()
    {
        anotherUI = UIManager.instance.AnotherInventoryMenu.GetComponentInChildren<AnotherUI>();
        //inventorys = gameObject.GetComponent<PlayerInvList>().list;
    }

    public void OpenInventory(Inventory inventory)
    {
        Time.timeScale = 0;
        anotherUI.OpenInventory(inventory);
        IsAnyChestOpened = true;
    }

    public void CloseInventory()
    {
        Time.timeScale = 1;
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
