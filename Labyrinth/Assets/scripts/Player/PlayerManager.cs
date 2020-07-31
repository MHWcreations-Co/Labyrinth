using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static int CurrentHealth;
        public static int MaxHealth = 3;

        public static GameObject Player;

        private void Awake()
        {
            Player = GameObject.FindWithTag("Player");
        }

        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        private void Update()
        {
            Debug.Log(CurrentHealth);
        }
    }
}