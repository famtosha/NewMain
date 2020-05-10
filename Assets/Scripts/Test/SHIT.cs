using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHIT : MonoBehaviour
{
    public ItemSpawner ItemSpawner;

    private void Start()
    {
        var item = ItemSpawner.SpawnRandomItem(ItemType.food);
        item.transform.position = transform.position;
    }
}
