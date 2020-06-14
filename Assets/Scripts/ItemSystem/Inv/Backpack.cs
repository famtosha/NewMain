using UnityEngine;

public class Backpack : Inventory
{
    public void Start()
    {
        base._inventory = new GameObject[10];
    }
}