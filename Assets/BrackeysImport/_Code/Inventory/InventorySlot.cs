using _Code;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

    public class InventorySlot : MonoBehaviour
    {
        public Image icon;
        [SerializeField] private InventoryItemBaseData item;
        [SerializeField] private Button removeButton;

        public void AddItem(InventoryItemBaseData newItem)
        {
            item = newItem;

            icon.sprite = item.Icon;
            icon.enabled = true;

            removeButton.interactable = true;
        }

        public void ClearSlot()
        {
            item = null;

            icon.sprite = null;
            icon.enabled = false;
            
            removeButton.interactable = false;
        }

        public void OnRemoveButton()
        {
            Inventory.instance.Remove(item);
        }

        public void UseItem()
        {
            if (item != null)
            {
                // item.UseItem();
            }
            
        }
    }
