using _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData;
using UnityEngine;

namespace _Code
{
    [RequireComponent(typeof(Interactable))]
    [RequireComponent(typeof(Rigidbody))]
    public class EquipmentInstance : MonoBehaviour
    {
        public EquipmentStats BaseStats;
        [SerializeField] private float pickupFailPulse = 2.0f;
        private Rigidbody body;
        
        private void Awake()
        {
            GetComponent<Interactable>().HiddenInteraction.AddListener(AddToInventory);
            body = GetComponent<Rigidbody>();
        }

        public void AddToInventory()
        {
            if (!Inventory.instance.AddItem(BaseStats))
            {
                body.AddForce(Vector3.up* pickupFailPulse,ForceMode.Impulse);
                body.AddTorque(Vector3.up* pickupFailPulse,ForceMode.Impulse);
            }
        }
    }
}