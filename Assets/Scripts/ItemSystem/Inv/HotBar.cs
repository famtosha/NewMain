using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBar : Inventory
{
    public event Action<int, bool> OnChangeSelectedItem;

    private ItemShower ItemShower;

    private void Start()
    {
        _inventory = new GameObject[9];
        ItemShower = gameObject.GetComponentInChildren<ItemShower>();
    }

    protected override void UpdateSlot(int ID)
    {
        base.UpdateSlot(ID);
        if (_inventory[ID] == null)
        {
            ItemShower.HideItem();
        }
        else
        {
            if(ID == HotBarSelected)
            {
                ItemShower.ShowItem(_inventory[ID]);
            }
        }
    }

    private int _hotBarSelected = 0;

    public int HotBarSelected
    {
        get { return _hotBarSelected; }
        private set
        {
            if(OnChangeSelectedItem != null)
            {
                ItemShower.HideItem();
                OnChangeSelectedItem(_hotBarSelected,false);
                _hotBarSelected = value;
                OnChangeSelectedItem(value,true);
                ItemShower.ShowItem(_inventory[value]);
            }
        }
    }

    private void SelectNext()
    {
        if(HotBarSelected == _inventory.Length - 1)
        {
            HotBarSelected = 0;
        }
        else
        {
            HotBarSelected++;
        }
    }

    private void SelectPrev()
    {
        if(HotBarSelected == 0)
        {
            HotBarSelected = _inventory.Length - 1;
        }
        else
        {
            HotBarSelected--;
        }
    }

    private void UseItem()
    {
        var item = _inventory[HotBarSelected];
        if(item)
        {
            item.GetComponent<Item>().UseItem(out bool IsUsed);
            if (IsUsed)
            {
                _inventory[HotBarSelected] = null;
                UpdateSlot(HotBarSelected);
            }
        }
    }   

    private void ReloadWeapon()
    {
        var item = _inventory[HotBarSelected];
        if (item)
        {
            ((Weapon)item.GetComponent<Item>())?.Reload();
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) SelectNext();
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) SelectPrev();
        if(Input.GetKey(KeyCode.E)) UseItem();
        if (Input.GetKeyDown(KeyCode.R)) ReloadWeapon();
    }
}
