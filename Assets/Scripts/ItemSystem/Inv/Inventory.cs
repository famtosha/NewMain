using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected GameObject[] _inventory = new GameObject[24];

    public Arm Arm;
    public int InventorySize => _inventory.Length;
    public event Action<int,ItemData> _updateSlot;

    virtual protected void UpdateSlot(int ID)
    {
        _updateSlot?.Invoke(ID, GetData(ID));
    }

    public void AddToInventory(GameObject Item,int Slot)
    {      
        _inventory[Slot] = Item;
        Item.transform.SetParent(gameObject.transform);
        Item.GetComponent<Item>().PlayerTransform = gameObject.transform;
        UpdateSlot(Slot);
    }

    public GameObject RemoveFromInventory(int Slot)
    {
        if(_inventory[Slot] != null) _inventory[Slot].transform.SetParent(null);
        var x = _inventory[Slot];
        _inventory[Slot] = null;      
        return x;
    }

    public bool AddToFreeSlot(GameObject Item)
    {
        for (int i = 0; i < _inventory.Length; i++)
        {
            var ItemData = Item.GetComponent<Item>().ItemDataCurrend;
            if (_inventory[i] == null)
            {
                AddToInventory(Item, i);
                return true;
            }
            else if(ItemData.Name == _inventory[i].GetComponent<Item>().ItemDataCurrend.Name)
            {
                if(ItemData.Count + _inventory[i].GetComponent<Item>().ItemDataCurrend.Count <= ItemData.MaxCount)
                {
                    _inventory[i].GetComponent<Item>().ItemDataCurrend.Count += ItemData.Count;
                    Destroy(Item);
                    UpdateSlot(i);
                    return true;
                }
                else
                {
                    var totalcount = _inventory[i].GetComponent<Item>().ItemDataCurrend.Count + ItemData.Count;
                    var over = totalcount - ItemData.MaxCount;
                    _inventory[i].GetComponent<Item>().ItemDataCurrend.Count = ItemData.MaxCount;
                    ItemData.Count = over;
                    UpdateSlot(i);
                }
            }
        }
        return false;
    }

    public void SwitchItems(int First, int Second)
    {

        if(_inventory[First] != null && _inventory[Second] != null && _inventory[First].GetComponent<Item>().ItemDataCurrend.Name == _inventory[Second].GetComponent<Item>().ItemDataCurrend.Name)
        {
            var firstItem = _inventory[First].GetComponent<Item>();
            var secondItem = _inventory[Second].GetComponent<Item>();

            var sum = firstItem.Count + secondItem.Count;
            if (sum > firstItem.ItemDataCurrend.MaxCount)
            {
                var over = sum - firstItem.ItemDataCurrend.MaxCount;
                secondItem.ItemDataCurrend.Count = secondItem.ItemDataCurrend.MaxCount;
                firstItem.ItemDataCurrend.Count = over;
            }
            else
            {
                secondItem.ItemDataCurrend.Count = sum;
                var Item = _inventory[First];
                _inventory[First] = null;
                Destroy(Item);

            }
        }
        else
        {
            var Third = _inventory[Second];
            _inventory[Second] = _inventory[First];
            _inventory[First] = Third;
        }

        UpdateSlot(First);
        UpdateSlot(Second);
    }

    public void SwitchItemsMultiInv(int FSlot, Inventory FInventory, int SSlot, Inventory SInventory)
    {
        var FItem = FInventory.RemoveFromInventory(FSlot);
        var SItem = SInventory.RemoveFromInventory(SSlot);


        if (FItem)
        {
            SInventory.AddToInventory(FItem, SSlot);
        }
        if (SItem)
        {
            FInventory.AddToInventory(SItem, FSlot);
        }
                  
        FInventory.UpdateSlot(FSlot);
        SInventory.UpdateSlot(SSlot);
    }

    public GameObject GetSlotInfo(int SlotNum)
    {
        return _inventory[SlotNum];
    }

    public ItemData GetData(int SlotNum)
    {
        var data = _inventory[SlotNum];
        if(data == null)
        {
            return null;
        }
        else
        {
            return data.GetComponent<Item>().ItemDataCurrend;
        }
        
    }

    public void DropItem(int ID)
    {
        var Item = _inventory[ID];
        if(Item != null)
        {
            Arm.DropItem(Item);
            RemoveFromInventory(ID);
        }
        UpdateSlot(ID);
    }
}
