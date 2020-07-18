using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOperations : MonoBehaviour
{
    public static void DecreaseHealth(GameObject target, int currentHealth, int quantity)
    {
        
        currentHealth -= quantity;

        if (currentHealth <= 0)
        {
            DeathOperations.KillTarget(target);
        }

        if (target.CompareTag("Player"))
        {
            HealthVisualization.HealthRefresher(currentHealth);
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