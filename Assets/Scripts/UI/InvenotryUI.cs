using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InvenotryUI : MonoBehaviour
{ 
    public GameObject SlotModel;
    private int SelectedSlot = -1;
    [SerializeField] protected  GameObject[] SlotList;
    public Inventory inventory;
    public UIManager UIManager;
    public PlayerInvList playerInvList;

    protected void Start()
    {

        inventory._updateSlot += UpdateSlot;

        SlotList = new GameObject[inventory.InventorySize];
        for (int i = 0; i < SlotList.Length; i++)
        {
            var slot = Instantiate(SlotModel);
            slot.GetComponent<SlotUI>().ID = i;
            slot.GetComponent<SlotUI>().BackPackUI = this;
            slot.GetComponent<SlotUI>().UIManager = UIManager;
            slot.transform.SetParent(gameObject.transform);
            SlotList[i] = slot;
        }
    }

    public void UpdateSlot(int SlotNum, ItemData trashData)
    {       
        if (trashData == null)
        {
            ResetSlot(SlotNum);
        }
        else
        {
            SlotList[SlotNum].GetComponent<SlotUI>().UpdateData(trashData);
        }                       
    }

    public void ResetSlot(int ID)
    {
        Destroy(SlotList[ID]);
        var slot = Instantiate(SlotModel);
        SlotList[ID] = slot;
        slot.GetComponent<SlotUI>().ID = ID;
        slot.GetComponent<SlotUI>().BackPackUI = this;
        slot.GetComponent<SlotUI>().UIManager = UIManager;
        slot.transform.SetParent(gameObject.transform);
        slot.transform.SetSiblingIndex(ID);
    }

    public void DropItem(int ID)
    {
        inventory.DropItem(ID);
    }

    public void LeftClick(int ID)
    {
        if(SelectedSlot == ID)
        {
            SelectedSlot = -1;
        }
        else
        {
            foreach(var x in playerInvList.list)
            {
                if(x.inventory != null && x.inventory != inventory && x.SelectedSlot != -1)
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
                if(inventory.GetSlotInfo(ID) != null)
                {
                    SelectedSlot = ID;
                    return;
                }
            }

        }
    }

    public void RightClick(int ID)
    {

    }
}
