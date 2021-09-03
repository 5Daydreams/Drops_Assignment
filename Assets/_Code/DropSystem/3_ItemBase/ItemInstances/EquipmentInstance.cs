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
    
    public class EquipmentInstance : ItemInstanceBase
    {
        public EquipmentBaseData BaseData;
        [Header("Implicits")]
        private List<StatValue> ImplicitValues;
        public List<ModifierHolder> ImplicitModPool;
        
        [Header("Explicits")]
        public ItemRarity Rarity;
        public List<ModifierHolder> ExplicitModPool;
        protected List<StatValue> RolledModValues = new List<StatValue>();

        public void RollImplicitModifierValues()
        {
            foreach (var mod in ImplicitModPool)
            {
                ImplicitValues = mod.RollModifierValues();
            }
        }
        
        protected override void Awake()
        {
            base.Awake();
            SetupSpriteRenderer(BaseData);
        }

        protected override void SetupSpriteRenderer(ItemBaseData baseData)
        {
            if (baseData.Sprite == null)
            {
                Debug.LogError("Base item Scriptable has no sprite associated");
                return;
            }

            this._renderer.sprite = baseData.Sprite;
        }
    }
}