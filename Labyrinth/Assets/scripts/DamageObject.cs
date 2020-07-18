using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageObject : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] private int damage;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == PlayerManager.Player)
        {
            HealthOperations.DecreaseHealth(other.gameObject, PlayerManager.CurrentHealth, damage);
        }
        else if (other.gameObject.CompareTag("Entity"))
        {
            HealthOperations.DecreaseHealth(other.gameObject, 10, damage);
        }
    }
}