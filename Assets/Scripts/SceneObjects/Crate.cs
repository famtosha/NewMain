using UnityEngine;

public class Crate : Target
{
    [SerializeField] private ItemType ItemDropType = ItemType.Default;

    protected override void Death()
    {
        var item = ItemSpawner.instance.SpawnRandomItem(ItemDropType);
        item.transform.position = gameObject.transform.position;
        base.Death();
    }
}