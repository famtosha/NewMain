using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInvList : MonoBehaviour
{
    [HideInInspector] public InventoryUI BackPack;
    [HideInInspector] public InventoryUI HotBar;
    [HideInInspector] public InventoryUI AnotherInv;

    [HideInInspector] public List<InventoryUI> list = new List<InventoryUI>();

    private void Start()
    {
        BackPack = UIManager.instance.BackPackMenu.GetComponent<BackPackUI>();
        HotBar = UIManager.instance.HotBar.GetComponent<HotBarUI>();
        AnotherInv = UIManager.instance.AnotherInventoryMenu.GetComponent<StorageUI>();

        list[0] = BackPack;
        list[1] = HotBar;
        list[2] = AnotherInv;
    }
}
