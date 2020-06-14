public class BackPackUI : InventoryUI
{
    protected override void Start()
    {
        inventory = GameMan.instance.Player.GetComponent<Backpack>();
        base.Start();
    }
}