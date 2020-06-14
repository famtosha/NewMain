using UnityEngine;

public class HotBarUI : InventoryUI
{
    public GameObject ArmPos;

    protected override void Start()
    {
        inventory = GameMan.instance.Player.GetComponent<HotBar>();
        base.Start();
        ((HotBar)inventory).OnChangeSelectedItem += UpdateSlot;
        SlotList[((HotBar)inventory).HotBarSelected].GetComponent<SlotUI>().ChangeColor(Color.cyan);
    }

    public void EnableItem(int num)
    {
        SlotList[num].GetComponent<SlotUI>().ChangeColor(Color.cyan);
    }

    public void DisableItem(int num)
    {
        SlotList[num].GetComponent<SlotUI>().ChangeColor(Color.white);
    }

    private void UpdateSlot(int num, bool active)
    {
        if (active)
        {
            EnableItem(num);
        }
        else
        {
            DisableItem(num);
        }
    }
}
