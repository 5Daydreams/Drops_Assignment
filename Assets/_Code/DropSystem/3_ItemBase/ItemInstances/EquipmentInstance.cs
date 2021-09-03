using System;
using System.Collections.Generic;
using _Code.ModifierOperations;
using UnityEngine;

namespace _Code
{
    public class EquipmentInstance : ItemInstanceBase
    {
        public ItemRarity Rarity;
        public EquipmentBaseData BaseData;
        public Modifier Implicit;
        public List<Modifier> ModifierPool;
        protected List<ModifierValue> RolledModValues = new List<ModifierValue>();

        public void RollImplicitModifierValues()
        {
            // var targetStat = implicitMod.ModTargetStat;
            // var targetStat = implicitMod.modValueInfoOperation;
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