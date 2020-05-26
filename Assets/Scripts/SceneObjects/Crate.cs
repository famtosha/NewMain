using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : Target
{
    [SerializeField] ItemType ItemDropType = ItemType.Default;
    protected override void Death()
    {      
        var Item = ItemSpawner.instance.SpawnRandomItem(ItemDropType);
        Item.transform.position = gameObject.transform.position;
        base.Death();
    }
}
