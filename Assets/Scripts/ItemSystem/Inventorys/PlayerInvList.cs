using System.Collections.Generic;
using UnityEngine;

public class PlayerInvList : MonoBehaviour
{
    [HideInInspector] public InventoryUI BackPack;
    [HideInInspector] public InventoryUI HotBar;
    [HideInInspector] public InventoryUI AnotherInv;
    [HideInInspector] public List<InventoryUI> list = new List<InventoryUI>();

    private void Start()
    {
        BackPack = UIManager.instance.backPackMenu.GetComponent<BackPackUI>();
        HotBar = UIManager.instance.hotBar.GetComponent<HotBarUI>();
        AnotherInv = UIManager.instance.anotherInventoryMenu.GetComponent<StorageUI>();

        list[0] = BackPack;
        list[1] = HotBar;
        list[2] = AnotherInv;
    }
}
