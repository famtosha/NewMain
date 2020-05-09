using System;
using System.Collections;
using UnityEngine;

class Supply : Item
{
    public override void UseItem(out bool IsUsed)
    {
        var data = ((SupplyData)ItemDataCurrend);
        var playerStats = PlayerTransform.gameObject.GetComponent<PlayerStats>();
        playerStats.Health += data.HealthGive;
        playerStats.Thirst += data.WaterGive;
        playerStats.Hunger += data.FoodGive;
        playerStats.Temperature += data.TemperatureGive;
        base.RemoveItem();
        base.UseItem();
        IsUsed = true;
        Destroy(gameObject);
    }
}

