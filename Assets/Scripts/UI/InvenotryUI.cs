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

    private void Update()
    {
        if(SelectedSlot != -1)
        {
            //SlotList[SelectedSlot].GetComponent<SlotUI>().ItemSprite.transform.position = Input.mousePosition + new Vector3(3,-1,0);
        }
    }

    public void UpdateSlot(int SlotNum, ItemData trashData)
    {       
        if (trashData == null)
        {
            Debug.Log("Clear" + SlotNum);
            ResetSlot(SlotNum);
        }
        else
        {
            Debug.Log("update Slot" + SlotNum);
            SlotList[SlotNum].GetComponent<SlotUI>().UpdateData(trashData);
        }                       
    }

    public void RightClick(int ID)
    {
        //for (int i = 0; i < playerInvList.list.Count; i++)
        //{
        //    if (playerInvList.list[i].SelectedSlot != -1) return; 
        //}

        if (SelectedSlot == -1)
        {
            SelectedSlot = ID;
            Debug.Log("Select: " + SelectedSlot);
            return;
        }
        if (SelectedSlot == ID)
        {
            SelectedSlot = -1;
            Debug.Log("Select the same Slot!");
            return;
        }
        if (inventory.GetSlotInfo(SelectedSlot) != null)
        {
            Debug.Log("Switch: " + SelectedSlot + " " + ID);
            inventory.SwitchItems(SelectedSlot, ID);
            SelectedSlot = -1;
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

    public void NewClick(int ID)
    {
        if(SelectedSlot == ID)
        {
            SelectedSlot = -1;
            print("1Select the same Slot!");
        }
        else
        {
            foreach(var x in playerInvList.list)
            {
                if(x.inventory != null && x.inventory != inventory && x.SelectedSlot != -1)
                {
                    inventory.SwitchItemsMultiInv(x.SelectedSlot, x.inventory, ID, inventory);
                    x.SelectedSlot = -1;
                    print("2switch between inv");
                    return;
                }           
            }

            if (SelectedSlot != -1)
            {

                inventory.SwitchItems(SelectedSlot, ID);
                Debug.Log("3Switch: " + SelectedSlot + " " + ID);
                SelectedSlot = -1;
                return;
            }
            else
            {
                if(inventory.GetSlotInfo(ID) != null)
                {
                    SelectedSlot = ID;
                    Debug.Log("4Select: " + SelectedSlot);
                    return;
                }
            }

        }
    }
}
