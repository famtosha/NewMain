using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarUI : InventoryUI
{
    public GameObject ArmPos;

    protected override void Start()
    {
        inventory = GameMan.instance.Player.GetComponent<HotBar>();

        base.Start();
        ((HotBar)inventory).OnChangeSelectedItem += UpdateSlot;


        SlotList[((HotBar)inventory).HotBarSelected].GetComponent<SlotUI>().ChangeColor(Color.cyan);
    }

    public void EnableItem(int Num)
    {
        SlotList[Num].GetComponent<SlotUI>().ChangeColor(Color.cyan);     
    }

    public void DisableItem(int Num)
    {
        SlotList[Num].GetComponent<SlotUI>().ChangeColor(Color.white);    
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
}
