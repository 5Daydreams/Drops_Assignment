using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class InventoryItemBase : MonoBehaviour
{
    public string Name;
    public Sprite InventoryIcon;
    public ItemRarity Rarity;

    public abstract void UseItem();
}

[Serializable] 
public class ItemRarity
{
    public Color RarityColor = Color.white;
    public int MinModSlots = 0;
    public int MaxModSlots = 2;

    public int GetModCountFromRarity()
    {
        return Random.Range(MinModSlots, MaxModSlots + 1);
    }
}
