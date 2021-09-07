using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        new public string name = "New Item";
        public Sprite icon = null;

        public bool isDefault = false;

        public virtual void UseItem()
        {
            Debug.Log("Using the item: " + this.name);
        }

        public void RemoveFromInventory()
        {
            Inventory.instance.Remove(this);
        }
    }
}