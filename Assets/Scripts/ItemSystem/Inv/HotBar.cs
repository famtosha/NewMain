using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBar : Inventory
{
    private void Start()
    {
        _inventory = new GameObject[9];
    }
}
