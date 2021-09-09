using System;
using System.Collections.Generic;
using _Code.ModifierOperations;
using UnityEngine;

namespace _Code
{
    [Serializable] public class ItemRarity
    {
        public Color RarityColor = Color.white;
        public int MaxModSlots = 0;
    }
    
    [RequireComponent(typeof(Interactable))]
    public class EquipmentInstance : MonoBehaviour
    {
        [SerializeField] protected MeshRenderer _renderer;
        public EquipmentBaseData BaseData;
        
        [Header("Implicits")]
        [SerializeField] private List<StatValue> ImplicitValues;
        public List<ModifierHolder> ImplicitModPool;
        
        [Header("Explicits")]
        public ItemRarity Rarity;
        public List<ModifierHolder> ExplicitModPool;
        protected List<StatValue> RolledModValues = new List<StatValue>();

        private void Awake()
        {
            GetComponent<Interactable>().HiddenInteraction.AddListener(AddToInventory);
        }

        public void RollImplicitModifierValues()
        {
            foreach (var mod in ImplicitModPool)
            {
                ImplicitValues = mod.RollModifierValues();
            }
        }
        
        public void AddToInventory()
        {
            if (Inventory.instance.AddItem(BaseData))
            {
                Destroy(gameObject);
            }
        }
    }
}