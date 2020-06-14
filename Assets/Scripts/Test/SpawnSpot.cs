using UnityEngine;

public class SpawnSpot : MonoBehaviour
{
    public ItemSpawner ItemSpawner;
    public ItemType ItemType;

    private void Start()
    {
        var item = ItemSpawner.SpawnRandomItem(ItemType);
        item.transform.position = transform.position;
        Destroy(gameObject);
    }
}