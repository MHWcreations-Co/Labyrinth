using Player;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [SerializeField] [Range(1, 5)] private int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.gameObject.CompareTag("Player"))
        {
            HealthOperations.DecreaseHealth(other.gameObject, PlayerManager.CurrentHealth, damage);
        }
        else if (other.gameObject.CompareTag("Entity"))
        {
           Debug.Log("Entity detected"); //HealthOperations.DecreaseHealth(other.gameObject, 10, damage);
        }
    }
}