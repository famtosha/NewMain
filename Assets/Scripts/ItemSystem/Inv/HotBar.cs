using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBar : Inventory
{
    private void Start()
    {
        _inventory = new GameObject[9];
    }

    public event Action<int,bool> OnChangeSelectedItem;

    private int _hotBarSelected = 0;

    private int HotBarSelected
    {
        get { return _hotBarSelected; }
        set
        {
            if(OnChangeSelectedItem != null)
            {
                OnChangeSelectedItem(_hotBarSelected,false);
                _hotBarSelected = value;
                OnChangeSelectedItem(value,true);
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
            item.GetComponent<Item>().UseItem(out bool Isused);
            if (Isused)
            {
                _inventory[HotBarSelected] = null;
                OnChangeSelectedItem(HotBarSelected, false);
                UpdateSlot(HotBarSelected);
            }
        }
    }   

    private void ReloadWeapon()
    {
        var item = _inventory[HotBarSelected];
        if (item)
        {
            ((Weapon)item.GetComponent<Item>()).Reload();
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) SelectNext();
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) SelectPrev();
        if(Input.GetMouseButton(0)) UseItem();
        if (Input.GetKeyDown(KeyCode.R)) ReloadWeapon();
    }
}
