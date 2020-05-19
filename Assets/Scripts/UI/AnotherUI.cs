using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherUI : InventoryUI
{

    new private void Start()
    {
        
    }

    public void OpenInventory(Inventory ChestInventory)
    {
        inventory = ChestInventory;
        inventory._updateSlot += UpdateSlot;
        SlotList = new GameObject[inventory.InventorySize];
        for (int i = 0; i < inventory.InventorySize; i++)
        {
            var slot = Instantiate(SlotModel);          
            SlotList[i] = slot;         
            slot.GetComponent<SlotUI>().ID = i;
            slot.GetComponent<SlotUI>().BackPackUI = this;
            slot.GetComponent<SlotUI>().UIManager = UIManager;
            slot.transform.SetParent(gameObject.transform);
            UpdateSlot(i, inventory.GetData(i));
        }
        UIManager.EnableAnotherInventoryMenu();
    }

    public void CloseInvenotory()
    {       
        for (int i = 0; i < SlotList.Length; i++)
        {
            var x = SlotList[i];
            SlotList[i] = null;
            Destroy(x);
        }
        inventory._updateSlot -= UpdateSlot;
        inventory = null;
        UIManager.DisableAnotherInventoryMenu();
    }
}
