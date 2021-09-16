using UnityEngine;

namespace _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData
{
    public abstract class InventoryItemBase : MonoBehaviour
    {
        public string Name;
        public Sprite InventoryIcon;
        public RarityPoolGroup RarityPoolGroup;
        public ItemRarity CurrentRarity;

        public abstract void SpawnItem(Vector3 position, Quaternion rotation, Transform parent);
        public abstract void SpawnItem(Vector3 position, Quaternion rotation);
        public abstract string GetTooltip();
        
        public abstract void UseItem();
    }
}