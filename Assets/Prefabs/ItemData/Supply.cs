using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Supply : Item
{
    public override void UseItem()
    {
        var data = ((SupplyData)ItemDataCurrend);
        var playerStats = PlayerTransform.gameObject.GetComponent<PlayerStats>();
        playerStats.Health += data.HealthGive;
        playerStats.Thirst += data.WaterGive;
        playerStats.Hunger += data.FoodGive;
        playerStats.Temperature += data.TemperatureGive;
        base.RemoveItem();
        base.UseItem();
        Destroy(gameObject);
    }
}

