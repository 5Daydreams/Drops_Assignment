using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BrackeysImport._Code.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        public Transform itemsParent;
        public GameObject inventoryUI;
        public string ToggleInventoryKey;
        
        private Inventory inventory;
        private List<InventorySlot> slots;
        
        public void Start()
        {
            inventory  = Inventory.instance;
            inventory.onItemChangedCallback += UpdateUI;

            slots = itemsParent.GetComponentsInChildren<InventorySlot>().ToList();
        }

        private void Update()
        {
            if (Input.GetKeyDown(ToggleInventoryKey))
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
            }
        }

        private void UpdateUI()
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (i < inventory.items.Count)
                    slots[i].AddItem(inventory.items[i]);
                else
                    slots[i].ClearSlot();
            }
        }
    }
}