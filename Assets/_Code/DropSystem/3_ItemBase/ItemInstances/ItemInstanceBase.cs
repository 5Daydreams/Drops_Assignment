using System;
using System.Net.Mime;
using UnityEngine;

namespace _Code
{
    [RequireComponent(typeof(SpriteRenderer))] [ExecuteAlways]
    public abstract class ItemInstanceBase : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer _renderer;

        protected virtual void Awake()
        {
            Debug.LogWarning("RED FLAG: this object uses ExecuteAlways");
            if (_renderer == null)
            {
                _renderer = GetComponent<SpriteRenderer>();
            }
        }

        protected abstract void SetupSpriteRenderer(ItemBaseData baseData);
    }
}