using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvList : MonoBehaviour
{
    public InventoryUI BackPack;
    public InventoryUI HotBar;
    public InventoryUI AnotherInv;

    public List<InventoryUI> list = new List<InventoryUI>();
}
