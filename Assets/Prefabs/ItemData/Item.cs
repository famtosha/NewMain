using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public event Action OnItemRemoved;

    [SerializeField] protected ItemData ItemDataOrigin;
    [SerializeField] public ItemData ItemDataCurrend;
    public Transform PlayerTransform;

    public string Name => ItemDataCurrend.Name;
    public int Count => ItemDataCurrend.Count;

    protected virtual void Start()
    {
        ItemDataCurrend = Instantiate(ItemDataOrigin);
    }

    public virtual string GetInfo()
    {
        string result = "";
        result += ItemDataCurrend.Description;
        return result;
    }

    public virtual void RemoveItem()
    {
        OnItemRemoved?.Invoke();
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
