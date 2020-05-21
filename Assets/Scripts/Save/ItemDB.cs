using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public Dictionary<int, GameObject> ItemDictionary = new Dictionary<int, GameObject>();
    public static ItemDB instance = null;

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

        LoadDataBase();
    }

    private void LoadDataBase()
    {
        GameObject[] items = Resources.LoadAll<GameObject>("Items");

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].GetComponent<Item>() != null)
            {
                ItemDictionary.Add(i, items[i]);
                items[i].GetComponent<Item>().ItemDataOrigin.ID = i;
            }
        }
    }

    public GameObject GetItem(int id)
    {
        try
        {
            var item = ItemDictionary[id];
            return item;
        }
        catch
        {
            Debug.Log("Cant get item from ItemDict " + id.ToString());
            return null;
        }
    }

    public List<GameObject> GetAllItems()
    {
        List<GameObject> Result = new List<GameObject>();

        for (int i = 0; i < ItemDictionary.Count; i++)
        {
            Result.Add(ItemDictionary[i]);
        }
        return Result;
    }

    public List<GameObject> GetAllItems(ItemType itemType)
    {
        List<GameObject> Result = new List<GameObject>();

        for (int i = 0; i < ItemDictionary.Count; i++)
        {
            if (ItemDictionary[i].GetComponent<Item>().ItemDataOrigin.ItemType == itemType)
            {
                Result.Add(ItemDictionary[i]);
            }
        }
        return Result;
    }

    public List<GameObject> GetAllItems(ItemRarity itemRarity)
    {
        List<GameObject> Result = new List<GameObject>();

        for (int i = 0; i < ItemDictionary.Count; i++)
        {
            if (ItemDictionary[i].GetComponent<Item>().ItemDataOrigin.Rarity == itemRarity)
            {
                Result.Add(ItemDictionary[i]);
            }
        }
        return Result;
    }

    public GameObject GetRandomItem()
    {
        var x = Random.Range(0, ItemDictionary.Count);
        return ItemDictionary[x];
    }

    public GameObject GetRandomItem(ItemRarity itemRarity)//shit
    {
        var items = GetAllItems(itemRarity);
        var item = items[Random.Range(0, items.Count)];
        return ItemDictionary.FirstOrDefault(t => t.Value == item).Value;
    }

    public GameObject GetRandomItem(ItemType itemType)//shit
    {
        if (itemType == ItemType.Default)
        {
            return GetRandomItem();
        }
        else
        {
            var items = GetAllItems(itemType);
            var item = items[Random.Range(0, items.Count)];
            return ItemDictionary.FirstOrDefault(t => t.Value == item).Value;
        }
    }
}
