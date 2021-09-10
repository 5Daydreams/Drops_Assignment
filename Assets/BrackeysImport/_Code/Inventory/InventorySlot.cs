using _Code;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    [SerializeField] private InventoryItemBase item;
    [SerializeField] private Button removeButton;

    public void AddItem(InventoryItemBase newItem)
    {
        item = newItem;

        icon.sprite = item.InventoryIcon;
        icon.enabled = true;

        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
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