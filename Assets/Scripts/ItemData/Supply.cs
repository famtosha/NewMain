class Supply : Item
{
    public override void UseItem(out bool isUsed)
    {
        var data = ((SupplyData)ItemData);
        var playerStats = GameMan.instance.Player.GetComponent<Stats>().playerStats;
        playerStats.Health += data.HealthGive;
        playerStats.Thirst += data.WaterGive;
        playerStats.Hunger += data.FoodGive;
        playerStats.Liver += data.VodkaGive;
        playerStats.Temperature += data.TemperatureGive;
        base.RemoveItem();
        base.UseItem();
        isUsed = true;
        Destroy(gameObject);
    }
}