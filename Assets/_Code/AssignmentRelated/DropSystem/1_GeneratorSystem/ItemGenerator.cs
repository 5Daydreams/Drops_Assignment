using System.Collections.Generic;
using _Code.AssignmentRelated.DropSystem._2_Category;
using _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData;
using FG_Toolbox.MathExtensions;
using UnityEngine;

namespace _Code.AssignmentRelated.DropSystem._1_GeneratorSystem
{
    public class ItemGenerator : MonoBehaviour
    {
        [SerializeField] private List<ItemCategory> _categories;

        public void DropRandomItem()
        {
            InventoryItemBase selectedInstance = GetRandomItemBase(_categories);

            // drop items with a minor position offset
            float noisex = 0.5f * (Mathf.PerlinNoise(Time.time * 10.0f, 0) + 1);
            float noisey = 0.5f * (Mathf.PerlinNoise(Time.time * 10.0f, Time.time * 10.0f) + 1);
            float noisez = 0.5f * (Mathf.PerlinNoise(0, Time.time * 10.0f) + 1);

            Vector3 noiseVector = new Vector3(noisex, noisey, noisez);

        
#if UNITY_EDITOR
            selectedInstance.SpawnItem(this.transform.position + noiseVector, Quaternion.identity);
#else
        Instantiate(selectedInstance,this.transform.position + Vector3.right * noise ,Quaternion.identity);
#endif

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

        private InventoryItemBase GetRandomItemBase(List<ItemCategory> categories)
        {
            List<InventoryItemBase> dropList = new List<InventoryItemBase>();

            // Get all categories,
            foreach (var cat in categories)
            {
                // Within each category, Get the itemInstances
                foreach (var itemInstances in cat.ItemBases)
                {
                    dropList.Add(itemInstances);
                }
            }

            // returns a random item from all the categories searched
            return dropList.GetRandomElement();
        }
    }
}