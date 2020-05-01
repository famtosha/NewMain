using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected ItemData ItemDataOrigin;
    [SerializeField] public ItemData ItemDataCurrend;
    public Transform PlayerTransform;

    protected void Start()
    {
        ItemDataCurrend = Instantiate(ItemDataOrigin);
    }

    public string Name => ItemDataCurrend.Name;
    public int Count => ItemDataCurrend.Count;

    public virtual string GetInfo()
    {
        string result = "";
        result += ItemDataCurrend.Description;
        return result;
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
