using System.Collections.Generic;
using _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData;
using _Code.ControllerScripts;
using UnityEngine;

namespace BrackeysImport._Code.Inventory
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory instance;
        public List<InventoryItemBase> items = new List<InventoryItemBase>();
        [SerializeField] private int space;
        [SerializeField] private Vector3 dropOffset = Vector3.one;

        public delegate void OnItemChanged();

        public OnItemChanged onItemChangedCallback;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.Log("Error, multiple inventories found");
                return;
            }

            instance = this;
        }

        public bool AddItem(InventoryItemBase item)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }

            items.Add(item);
            StoreAsChild(item);
            onItemChangedCallback?.Invoke();

            return true;
        }

        public void Remove(InventoryItemBase item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                onItemChangedCallback?.Invoke();
            }
        }
    
        public void Drop(InventoryItemBase item)
        {
            if (items.Contains(item))
            {
                ReleaseItem(item);
                items.Remove(item);
                onItemChangedCallback?.Invoke();
            }
        }

        private void StoreAsChild(InventoryItemBase item)
        {
            item.gameObject.SetActive(false);
            item.transform.SetParent(PlayerSingleton.instance.player.transform);
            item.transform.localPosition = Vector3.zero; 
        }

        private void ReleaseItem(InventoryItemBase item)
        {
            item.transform.localPosition = dropOffset;
            item.transform.SetParent(null);
            item.gameObject.SetActive(true);
        }
    }
}