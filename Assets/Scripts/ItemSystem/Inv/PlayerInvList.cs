using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInvList : MonoBehaviour
{
    public InventoryUI BackPack;
    public InventoryUI HotBar;
    public InventoryUI AnotherInv;

    public List<InventoryUI> list = new List<InventoryUI>();

    private void Start()
    {
        BackPack = UIManager.instance.BackPackMenu.GetComponentInChildren<BackPackUI>();
        HotBar = UIManager.instance.HotBar.GetComponentInChildren<HotBarUI>();
        AnotherInv = UIManager.instance.AnotherInventoryMenu.GetComponentInChildren<StorageUI>();

        list[0] = BackPack;
        list[1] = HotBar;
        list[2] = AnotherInv;
    }
}
