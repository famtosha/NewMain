using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarUI : InvenotryUI
{
    public GameObject ArmPos;

    public override void UpdateSlot(int SlotNum, ItemData itemdata)
    {
        base.UpdateSlot(SlotNum, itemdata);
        if(itemdata != null)
        {
            UpdateSlot(SlotNum, false);
        }
        else
        {
            UpdateSlot(SlotNum, true);
        }
    }

    public void EnableItem(int Num)
    {
        SlotList[Num].GetComponent<SlotUI>().ChangeColor(Color.cyan);
        var item = inventory.GetSlotInfo(Num);
        if(item)
        {
            item.gameObject.SetActive(true);
            item.transform.position = ArmPos.transform.position;
            item.gameObject.transform.rotation = new Quaternion();
            item.GetComponent<BoxCollider2D>().enabled = false;
            item.gameObject.transform.Rotate(0, 0, 90);
            item.GetComponent<Item>().EquipItem();
        }      
    }

    public void DisableItem(int Num)
    {
        SlotList[Num].GetComponent<SlotUI>().ChangeColor(Color.white);
        var item = inventory.GetSlotInfo(Num);
        if(item)
        {
            item.gameObject.SetActive(false);
            item.GetComponent<BoxCollider2D>().enabled = true;
        }     
    }

    private void UpdateSlot(int Num, bool Active)
    {
        if (Active)
        {
            EnableItem(Num);
        }
        else
        {
            DisableItem(Num);
        }
    }

    new private void Start()
    {
        base.Start();
        ((HotBar)inventory).OnChangeSelectedItem += UpdateSlot;

        
    }
}
