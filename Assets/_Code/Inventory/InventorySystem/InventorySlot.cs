using _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData;
using UnityEngine;
using UnityEngine.UI;

namespace BrackeysImport._Code.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        public Image icon;
        [SerializeField] private TooltipWindow tooltipWindow;
        [SerializeField] private Button removeButton;
        private InventoryItemBase item;

        public void AddItem(InventoryItemBase newItem)
        {
            item = newItem;

            icon.sprite = item.InventoryIcon;
            icon.color = item.CurrentRarity.RarityColor;
            icon.enabled = true;

            removeButton.interactable = true;
            tooltipWindow.AdaptTooltip(item.GetTooltip());
        }

        public void ClearSlot()
        {
            icon.sprite = null;
            icon.enabled = false;

            removeButton.interactable = false;
            tooltipWindow.AdaptTooltip("Empty Slot");
        }

        public void OnRemoveButton()
        {
            Inventory.instance.Drop(item);
        }

        public void UseItem()
        {
            if (removeButton.interactable)
            {
                item.UseItem();
            }
        }
    }
}