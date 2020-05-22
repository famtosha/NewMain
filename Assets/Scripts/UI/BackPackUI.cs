﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackUI : InventoryUI
{
    protected override void Start()
    {
        inventory = GameMan.instance.Player.GetComponent<Backpack>();
        base.Start();
    }
}
