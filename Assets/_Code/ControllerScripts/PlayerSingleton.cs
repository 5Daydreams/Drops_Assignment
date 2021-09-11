using UnityEngine;

namespace _Code.ControllerScripts
{
    public class PlayerSingleton : MonoBehaviour
    {
        public static PlayerSingleton instance;

        public GameObject player;
    

        private void Awake()
        {
            instance = this;
        }
    }
}
