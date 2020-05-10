using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public ItemDB itemDB;

    public GameObject SpawnItem(int ID)
    {
        try
        {
            return Instantiate(itemDB.GetItem(ID));
        }
        catch
        {
            Debug.Log("Failed to spawn item " + ID.ToString());
            return null;
        }
    }

    public GameObject SpawnRandomItem()
    {
        var item = itemDB.GetRandomItem();
        return SpawnItem(item.GetComponent<Item>().ItemDataOrigin.ID);
    }

    public GameObject SpawnRandomItem(ItemRarity itemRarity)
    {
        var item = itemDB.GetRandomItem(itemRarity);
        return SpawnItem(item.GetComponent<Item>().ItemDataOrigin.ID);
    }

    public GameObject SpawnRandomItem(ItemType itemType)
    {
        var item = itemDB.GetRandomItem(itemType);
        return SpawnItem(item.GetComponent<Item>().ItemDataOrigin.ID);
    }
}
