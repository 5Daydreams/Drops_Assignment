using System.Collections.Generic;
using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierPool")]
    public class ModifierPool : ScriptableObject
    {
        public List<ModifierGroup> ModGroups;

        public List<ModifierGroupInstance> GetGroupInstances()
        {
            List<ModifierGroupInstance> instanceList = new List<ModifierGroupInstance>();

            foreach (var modGroup in ModGroups)
            {
                instanceList.Add(modGroup.GetAsInstance());
            }

            return instanceList;
        }
    }
}