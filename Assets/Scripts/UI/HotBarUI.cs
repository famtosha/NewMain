using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarUI : InvenotryUI
{
    public int _selectedItem = 1;

    public GameObject ArmPos;

    public int SelectedItem
    {
        get
        {
            return _selectedItem;
        }
        set
        {
            _selectedItem = value;
        }
    }

    public void SelectNextItem()
    {
        SlotList[SelectedItem].GetComponent<SlotUI>().ChangeColor(Color.white);
        DisableItem();
        if (_selectedItem + 1 == inventory.InventorySize)
        {
            SelectedItem = 0;
        }
        else
        {
            SelectedItem++;
        }
        SlotList[SelectedItem].GetComponent<SlotUI>().ChangeColor(Color.red);
        EnableItem();
    }

    public void SelectPrevItem()
    {
        SlotList[SelectedItem].GetComponent<SlotUI>().ChangeColor(Color.white);
        DisableItem();
        if (_selectedItem == 0)
        {
            SelectedItem = inventory.InventorySize - 1;          
        }
        else
        {
            SelectedItem--;
        }
        SlotList[SelectedItem].GetComponent<SlotUI>().ChangeColor(Color.red);
        EnableItem();
    }

    public void EnableItem()
    {
        
        var item = inventory.GetSlotInfo(_selectedItem);
        if(item != null)
        {
            item.gameObject.SetActive(true);
            item.transform.position = ArmPos.transform.position;
            item.gameObject.transform.rotation = new Quaternion();
            item.GetComponent<BoxCollider2D>().enabled = false;
            item.gameObject.transform.Rotate(0, 0, 90);
        }
    }

    public void DisableItem()
    {
        var item = inventory.GetSlotInfo(_selectedItem);
        if(item != null)
        {
            item.gameObject.SetActive(false);
            item.GetComponent<BoxCollider2D>().enabled = true;
        }     
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) SelectNextItem();
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) SelectPrevItem();
    }
}
