using UnityEngine;

public class SpawnSpot : MonoBehaviour
{
    public ItemType ItemType;

    private void Start()
    {
        var item = ItemSpawner.instance.SpawnRandomItem(ItemType);
        item.transform.position = transform.position;
        Destroy(gameObject);
    }
}