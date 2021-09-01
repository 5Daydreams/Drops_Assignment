using System.Collections;
using System.Collections.Generic;
using _Code;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private List<ItemCategory> _categories; 

    public void DropRandomItem()
    {
        // Select Drop Category
        
        // Within Category, Select Item Base Type
            // Check if rolled item extends IHasRarityRange
                // -- End for currency and quest items--
        
        // Roll pre-rarity Setups (Implicit value range, Quality value range, Influence enum*)
        
        // Roll Rarity
        
        // Within Rarity, Roll modifier Count

        // For each available modifier:
            // Roll Modifier Type/Stat
            // Roll Modifier Value Tier
            // Roll Modifier Value
            
        // Item has:
        // base type (name, sprite, categoryStats)
        // implicit (based on base type)
        // rarity (if available)
        // N mod slots filled (based on rarity)
        // mods with a rolled tier and value
        // 

    }
    
}
