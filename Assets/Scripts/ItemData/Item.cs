using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public event Action OnItemRemoved;

    [SerializeField] public ItemData ItemDataOrigin;
    [SerializeField] public ItemData ItemDataCurrend;
    public Transform PlayerTransform;

    public string Name => ItemDataCurrend.Name;
    public int Count => ItemDataCurrend.Count;

    private void Awake()
    {
        ItemDataCurrend = Instantiate(ItemDataOrigin);
    }

    protected virtual void Start()
    {
        
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

    public virtual void UseItem(out bool IsUsed)
    {
        IsUsed = false;
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
