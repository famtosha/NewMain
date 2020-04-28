using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBar : Inventory
{
    int SlotSelected = 0;
    private void Start()
    {
        _inventory = new GameObject[9];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_inventory[SlotSelected] != null)
            {
                _inventory[SlotSelected].GetComponent<Item>().UseItem();
            }        
        }    
    }
}
