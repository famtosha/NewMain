using UnityEngine;

public abstract class InventoryUI : MonoBehaviour
{
    public GameObject SlotModel;
    public Inventory inventory;
    private int SelectedSlot = -1;

    [SerializeField] protected GameObject[] SlotList;
    protected PlayerInvList playerInvList;

    protected virtual void Start()
    {
        playerInvList = GameMan.instance.Player.GetComponent<PlayerInvList>();
        inventory._updateSlot += UpdateSlot;
        SlotList = new GameObject[inventory.InventorySize];
        for (int i = 0; i < SlotList.Length; i++)
        {
            var slot = Instantiate(SlotModel);
            slot.GetComponent<SlotUI>().ID = i;
            slot.GetComponent<SlotUI>().BackPackUI = this;
            slot.transform.SetParent(gameObject.transform);
            SlotList[i] = slot;
        }
    }

    virtual public void UpdateSlot(int slotNum, ItemData itemData)
    {
        SlotList[slotNum].GetComponent<SlotUI>().UpdateData(itemData);
    }

    public void DropItem(int ID)
    {
        inventory.DropItem(ID);
    }

    public void LeftClick(int ID)
    {
        if (SelectedSlot == ID)
        {
            SelectedSlot = -1;
        }
        else
        {
            foreach (var x in playerInvList.list)
            {
                if (x.inventory != null && x.inventory != inventory && x.SelectedSlot != -1)
                {
                    inventory.SwitchItemsMultiInv(x.SelectedSlot, x.inventory, ID, inventory);
                    x.SelectedSlot = -1;
                    return;
                }
            }

            if (SelectedSlot != -1)
            {
                inventory.SwitchItems(SelectedSlot, ID);
                SelectedSlot = -1;
                return;
            }
            else
            {
                if (inventory.GetSlotInfo(ID) != null)
                {
                    SelectedSlot = ID;
                    return;
                }
            }

        }
    }

    public void RightClick(int id)
    {

    }
}
