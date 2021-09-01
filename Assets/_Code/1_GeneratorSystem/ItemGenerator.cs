using System.Collections;
using System.Collections.Generic;
using _Code;
using _Code.Extensions;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private List<ItemCategory> _categories; 

    public void DropRandomItem()
    {
        // Select Drop Category
        ItemCategory selectedCategory = _categories.GetRandomElement();

        // Within Category, Select Item Base Type
        ItemInstanceBase selectedInstance = selectedCategory.ItemBases.GetRandomElement();
        
        // Check if rolled item extends ICraftable
            // -- End for currency and quest items--
        Instantiate(selectedInstance);

        // Roll pre-rarity Setups (Implicit value range, Quality value range, Influence enum*)

        // Roll Rarity

        // Within Rarity, Roll modifier Count

        // For each available modifier {
            // Roll Modifier Type/Stat
            // Roll Modifier Value Tier
            // Roll Modifier Value
        // }

        // Final Item has:
        // base type (name, sprite, categoryStats)
        // implicit (based on base type)
        // rarity (if available)
        // N mod slots filled (based on rarity)
        // mods with a rolled tier and value
        // 
    }
    
}
