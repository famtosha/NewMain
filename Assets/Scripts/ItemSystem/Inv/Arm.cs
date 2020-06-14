using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public bool IsAnyChestOpened = false;
    public List<Inventory> inventorys;

    private StorageUI anotherUI;

    private void Start()
    {
        anotherUI = UIManager.instance.anotherInventoryMenu.GetComponentInChildren<StorageUI>();
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

    public void PickUpItem(GameObject item)
    {
        foreach (var inv in inventorys)
        {
            item.SetActive(false);
            if (inv.AddToFreeSlot(item))
            {
                item.transform.SetParent(gameObject.transform);
                return;
            }
            else
            {
                item.SetActive(true);
            }
        }
    }

    public void DropItem(GameObject item)
    {
        if (item == null) return;
        item.SetActive(true);
        item.transform.SetParent(null);
        item.transform.Translate(2, 0, 0);
    }
}
