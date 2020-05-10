using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public enum ItemRarity { common, uncommon, rare, epic, godlike }
public enum ItemType { weapon, weapon_part, material, trash, utilities, food }

[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 51)]

public class ItemData : ScriptableObject
{
    public ItemRarity rarity;
    public ItemType itemType;
    public int ID;
    [SerializeField] private string _name;
    [SerializeField] private int _count = 1;
    [SerializeField] private int _maxCount = 99;
    [SerializeField] private bool _craftability = false;
    [SerializeField] private bool _craftable = false;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _description;
    [SerializeField] private bool _tradable = false;
    [SerializeField] public ItemRarity _rarity = 0;
    [SerializeField] public ItemType _itemType = 0;
    
    public string Name
    {
        get
        {
            return _name; 
        }
    }
    public int Count
    {
        get 
        {
            return _count;
        }
        set
        {
            if (value >= 0 && value < _maxCount)
            {
                _count = value;
            }
        }
    }
    public int MaxCount
    {
        get
        {
            return _maxCount;
        }
        
    }
    public bool Craftability
    {
        get
        {
            return _craftability;
        }
        set
        {
            _craftability = value;
        }
    }
    public bool Craftable
    {
        get
        {
            return _craftable;
        }
        set
        {
            _craftable = value;
        }
    }
    public Sprite Sprite
    {
        get
        {
            return _sprite;
        }
        set
        {
            _sprite = value;
        }
    }
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }
    public bool Tradable
    {
        get
        {
            return _tradable;
        }
        set
        {
            _tradable = value;
        }
    }
}
