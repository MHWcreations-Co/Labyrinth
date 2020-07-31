using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int maxHealth = 3;
    private int currentHealth = 0;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Character>().ModifyHealth(-1);
        }
    }
}