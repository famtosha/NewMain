using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBar : Inventory
{
    public event Action<int, bool> OnChangeSelectedItem;
    private ItemShower ItemShower;

    private int _hotBarSelected = 0;

    public int HotBarSelected
    {
        get => _hotBarSelected;
        private set
        {
            if (OnChangeSelectedItem != null)
            {
                ItemShower.HideItem();
                OnChangeSelectedItem(_hotBarSelected, false);
                _hotBarSelected = value;
                OnChangeSelectedItem(value, true);
                ItemShower.ShowItem(_inventory[value]);
            }
        }
    }

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
            if (ID == HotBarSelected)
            {
                ItemShower.ShowItem(_inventory[ID]);
            }
        }
    }

    private void ChangeSelectedSlot(ScrolDirection direction)
    {

        if (direction == ScrolDirection.Next)
        {
            if (HotBarSelected == _inventory.Length - 1)
            {
                HotBarSelected = 0;
            }
            else
            {
                HotBarSelected++;
            }
        }
        else
        {
            if (HotBarSelected == 0)
            {
                HotBarSelected = _inventory.Length - 1;
            }
            else
            {
                HotBarSelected--;
            }
        }

    }

    private void UseItem()
    {
        if (!UIManager.instance.IsBackPackOpen)
        {
            var item = _inventory[HotBarSelected];
            if (item)
            {
                _inventory[HotBarSelected].GetComponent<Item>().UseItem(out bool IsUsed);
                if (IsUsed)
                {
                    _inventory[HotBarSelected] = null;
                    UpdateSlot(HotBarSelected);
                }
            }
        }
    }

    private void ReloadWeapon()
    {
        if (!UIManager.instance.IsBackPackOpen)
        {
            _inventory[HotBarSelected]?.GetComponent<Weapon>()?.Reload();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) UseItem();
        if (Input.GetKeyDown(KeyCode.R)) ReloadWeapon();
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) ChangeSelectedSlot(ScrolDirection.Next);
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) ChangeSelectedSlot(ScrolDirection.Prev);
    }
}
