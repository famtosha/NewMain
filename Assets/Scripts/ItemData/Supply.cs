using System;
using System.Collections;
using UnityEngine;

class Supply : Item
{
    public override void UseItem(out bool IsUsed)
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
        IsUsed = true;
        Destroy(gameObject);
    }
}

