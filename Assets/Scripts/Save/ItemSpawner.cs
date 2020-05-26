using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            print("Load IDB");
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    public GameObject SpawnItem(int ID)
    {
        try
        {
            return Instantiate(ItemDB.instance.GetItem(ID));
        }
        catch
        {
            Debug.Log("Failed to spawn item " + ID.ToString());
            return null;
        }
    }

    public GameObject SpawnRandomItem()
    {
        var item = ItemDB.instance.GetRandomItem();
        return SpawnItem(item.GetComponent<Item>().ItemDataOrigin.ID);
    }

    public GameObject SpawnRandomItem(ItemRarity itemRarity)
    {
        var item = ItemDB.instance.GetRandomItem(itemRarity);
        return SpawnItem(item.GetComponent<Item>().ItemDataOrigin.ID);
    }

    public GameObject SpawnRandomItem(ItemType itemType)
    {
        var item = ItemDB.instance.GetRandomItem(itemType);
        return SpawnItem(item.GetComponent<Item>().ItemDataOrigin.ID);
    }
}
