using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner instance = null;

    private void Awake()
    {
        instance = this;
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
        return SpawnItem(item.GetComponent<Item>().ItemData.ID);
    }

    public GameObject SpawnRandomItem(ItemRarity itemRarity)
    {
        var item = ItemDB.instance.GetRandomItem(itemRarity);
        return SpawnItem(item.GetComponent<Item>().ItemData.ID);
    }

    public GameObject SpawnRandomItem(ItemType itemType)
    {
        var item = ItemDB.instance.GetRandomItem(itemType);
        return SpawnItem(item.GetComponent<Item>().ItemData.ID);
    }
}
