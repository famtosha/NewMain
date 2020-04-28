using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : Inventory
{
    public void Start()
    {
        base._inventory = new GameObject[24];
    }
}
