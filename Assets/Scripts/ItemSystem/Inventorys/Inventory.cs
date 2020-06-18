using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected GameObject[] _inventory = new GameObject[24];
    public int InventorySize => _inventory.Length;
    public event Action<int, ItemData> _updateSlot;

    private Arm Arm;

    private void Start()
    {
        Arm = gameObject.GetComponent<Arm>();
    }

    virtual protected void UpdateSlot(int id)
    {
        _updateSlot?.Invoke(id, GetData(id));
    }

    public void AddToInventory(GameObject item, int slot)
    {
        _inventory[slot] = item;
        item.transform.SetParent(gameObject.transform);
        UpdateSlot(slot);
    }

    public GameObject RemoveFromInventory(int slot)
    {
        if (_inventory[slot] != null) _inventory[slot].transform.SetParent(null);
        var x = _inventory[slot];
        _inventory[slot] = null;
        return x;
    }

    public bool AddToFreeSlot(GameObject item)
    {
        for (int i = 0; i < _inventory.Length; i++)
        {
            var ItemData = item.GetComponent<Item>().ItemData;
            if (_inventory[i] == null)
            {
                AddToInventory(item, i);
                return true;
            }
            else if (ItemData.Name == _inventory[i].GetComponent<Item>().ItemData.Name)
            {
                if (ItemData.Count + _inventory[i].GetComponent<Item>().ItemData.Count <= ItemData.MaxCount)
                {
                    _inventory[i].GetComponent<Item>().ItemData.Count += ItemData.Count;
                    Destroy(item);
                    UpdateSlot(i);
                    return true;
                }
                else
                {
                    var totalcount = _inventory[i].GetComponent<Item>().ItemData.Count + ItemData.Count;
                    var over = totalcount - ItemData.MaxCount;
                    _inventory[i].GetComponent<Item>().ItemData.Count = ItemData.MaxCount;
                    ItemData.Count = over;
                    UpdateSlot(i);
                }
            }
        }
        return false;
    }

    public void SwitchItems(int first, int second)
    {

        if (_inventory[first] != null && _inventory[second] != null && _inventory[first].GetComponent<Item>().ItemData.Name == _inventory[second].GetComponent<Item>().ItemData.Name)
        {
            var firstItem = _inventory[first].GetComponent<Item>();
            var secondItem = _inventory[second].GetComponent<Item>();

            var sum = firstItem.Count + secondItem.Count;
            if (sum > firstItem.ItemData.MaxCount)
            {
                var over = sum - firstItem.ItemData.MaxCount;
                secondItem.ItemData.Count = secondItem.ItemData.MaxCount;
                firstItem.ItemData.Count = over;
            }
            else
            {
                secondItem.ItemData.Count = sum;
                var Item = _inventory[first];
                _inventory[first] = null;
                Destroy(Item);

            }
        }
        else
        {
            var Third = _inventory[second];
            _inventory[second] = _inventory[first];
            _inventory[first] = Third;
        }

        UpdateSlot(first);
        UpdateSlot(second);
    }

    public void SwitchItemsMultiInv(int firstSlot, Inventory firstInvenotyr, int secondSlot, Inventory secondInventory)
    {
        var firstItem = firstInvenotyr.RemoveFromInventory(firstSlot);
        var secondItem = secondInventory.RemoveFromInventory(secondSlot);

        if (firstItem)
        {
            secondInventory.AddToInventory(firstItem, secondSlot);
        }
        if (secondItem)
        {
            firstInvenotyr.AddToInventory(secondItem, firstSlot);
        }

        firstInvenotyr.UpdateSlot(firstSlot);
        secondInventory.UpdateSlot(secondSlot);
    }

    public GameObject GetSlotInfo(int slot)
    {
        return _inventory[slot];
    }

    public ItemData GetData(int slot)
    {
        var data = _inventory[slot];
        if (data == null)
        {
            return null;
        }
        else
        {
            return data.GetComponent<Item>().ItemData;
        }

    }

    public void DropItem(int id)
    {
        var item = _inventory[id];
        if (item != null)
        {
            Arm.DropItem(item);
            RemoveFromInventory(id);
        }
        UpdateSlot(id);
    }
}