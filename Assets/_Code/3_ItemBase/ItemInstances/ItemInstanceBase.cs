using System;
using System.Net.Mime;
using UnityEngine;

namespace _Code
{
    [RequireComponent(typeof(SpriteRenderer))] [ExecuteAlways]
    public abstract class ItemInstanceBase : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        public ItemBaseData BaseData;

        private void Awake()
        {
            Debug.LogWarning("RED FLAG: this object uses ExecuteAlways");
            if (_renderer == null)
            {
                _renderer = GetComponent<SpriteRenderer>();
            }

            if (_renderer.sprite == null)
            {
                _renderer.sprite = BaseData.Sprite;
            }
        }
    }
}