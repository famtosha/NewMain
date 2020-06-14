using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public ItemData ItemData;
    public event Action OnItemRemoved;
    public string Name => ItemData.Name;
    public int Count => ItemData.Count;

    private void Awake()
    {
        ItemData = Instantiate(ItemData);
    }

    protected virtual void Start()
    {

    }

    public virtual string GetInfo()
    {
        string result = "";
        result += ItemData.Description;
        return result;
    }

    public virtual void RemoveItem()
    {
        OnItemRemoved?.Invoke();
    }

    public virtual void UseItem(out bool isUsed)
    {
        isUsed = false;
    }

    public virtual void UseItem()
    {

    }

    public virtual void EquipItem()
    {

    }

    public virtual void UnEquipItem()
    {

    }
}