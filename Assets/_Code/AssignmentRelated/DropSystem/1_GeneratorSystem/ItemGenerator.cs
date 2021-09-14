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

            // this is to drop items with a minor random position offset
            float noisex = 0.5f * (Mathf.PerlinNoise(Time.time * 10.0f, 0) + 1);
            float noisey = 0.5f * (Mathf.PerlinNoise(Time.time * 10.0f, Time.time * 10.0f) + 1);
            float noisez = 0.5f * (Mathf.PerlinNoise(0, Time.time * 10.0f) + 1);

            Vector3 noiseVector = new Vector3(noisex, noisey, noisez);

            selectedInstance.SpawnItem(this.transform.position + noiseVector, Quaternion.identity);
        }

        private InventoryItemBase GetRandomItemBase(List<ItemCategory> categories)
        {
            List<InventoryItemBase> dropList = new List<InventoryItemBase>();

            foreach (var cat in categories)
            {
                foreach (var itemInstances in cat.ItemBases)
                {
                    dropList.Add(itemInstances);
                }
            }

            return dropList.GetRandomElement();
        }
    }
}