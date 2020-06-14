using UnityEngine;

public class StorageUI : InventoryUI
{

    protected override void Start()
    {
        playerInvList = GameMan.instance.Player.GetComponent<PlayerInvList>();
    }

    public void OpenInventory(Inventory chestInventory)
    {
        inventory = chestInventory;
        inventory._updateSlot += UpdateSlot;
        SlotList = new GameObject[inventory.InventorySize];
        for (int i = 0; i < inventory.InventorySize; i++)
        {
            var slot = Instantiate(SlotModel);
            SlotList[i] = slot;
            slot.GetComponent<SlotUI>().ID = i;
            slot.GetComponent<SlotUI>().BackPackUI = this;
            slot.transform.SetParent(gameObject.transform);
            UpdateSlot(i, inventory.GetData(i));
        }
        UIManager.instance.anotherInventoryMenu.EnablePanel();
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
        UIManager.instance.anotherInventoryMenu.DisablePanel();
    }
}