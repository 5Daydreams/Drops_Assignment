using System;
using System.Net.Mime;
using UnityEngine;

namespace _Code
{
    [RequireComponent(typeof(Rigidbody))] [ExecuteAlways]
    public abstract class ItemInstanceBase : MonoBehaviour
    {
        [SerializeField] protected MeshRenderer _renderer;
    }
}