using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject ChestPrefab;
    public ItemSpawner ItemSpawner;
    private Inventory ChestInventory;
    public Arm PlayerArm;
    public ItemType itemType;

    private void Start()
    {
        GameObject ChestClone = Instantiate(ChestPrefab,gameObject.transform.position, new Quaternion());
        ChestInventory = ChestClone.GetComponent<Inventory>();

        int itemCount = Random.Range(0, ChestInventory.InventorySize);
        for (int i = 0; i < itemCount; i++)
        {
            GameObject item = ItemSpawner.SpawnRandomItem(itemType);
            ChestInventory.AddToFreeSlot(item);
            item.SetActive(false);
        }
        Destroy(gameObject);
    }
}
