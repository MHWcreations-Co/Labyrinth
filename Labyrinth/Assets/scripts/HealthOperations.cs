using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class HealthOperations : MonoBehaviour
{
    PlayerHealthOperations pHO = new PlayerHealthOperations();
    EnemyHealthOperations eHO = new EnemyHealthOperations();

    private void Awake()
    {
    }

    public static void DecreaseHealth(GameObject target, int currentHealth, int quantity)
    {
        if (currentHealth <= 0)
        {
            DeathOperations.KillTarget(target);
        }
        
        //int nextHealth = currentHealth - quantity;

        if (target.CompareTag("Player"))
        {
            PlayerManager.CurrentHealth -= quantity;
            HealthVisualization.HealthRefresher(PlayerManager.CurrentHealth);
        }
        else
        {
            //todo: create EnemyManager class
            //target.GetComponent<EnemyManager>().health
        }
    }

    public static void IncreaseHealth(int maxHealth, int currentHealth, int quantity)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += quantity;
        }
    }

    void CheckTargetsHealth(GameObject target)
    {
    }
}