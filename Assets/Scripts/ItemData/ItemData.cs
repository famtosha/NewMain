using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 51)]

public class ItemData : ScriptableObject
{
    public ItemRarity Rarity = 0;
    public ItemType ItemType = 0;
    public int ID;
    public string Name;
    [SerializeField] private int _count = 1;
    public int MaxCount = 99;
    public Sprite SpriteInArm;
    public Sprite SpriteInWorld;
    public string Description;
    public bool Tradable = false;
    public bool Craftability = false;
    public bool Craftable = false;

    public int Count
    {
        get => _count;
        set { if (value >= 0 && value < MaxCount) { _count = value; } }
    }
}
