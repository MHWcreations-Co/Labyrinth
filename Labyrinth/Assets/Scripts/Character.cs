using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character instance;

    private int maxHealth = 3;
    private int CurrentHealth { get; set; } = 0;

    [Range(0, 16)] public float Speed;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void ModifyHealth(int healthModifier)
    {
        CurrentHealth += healthModifier;

        if (CurrentHealth <= 0)
        {
            Death();
            return;
        }

        print(CurrentHealth);
    }

    public void ModifySpeed(int amount)
    {
        //float amountF *= 1.1f; 
        Speed += amount;
        print(Speed);
    }

    private void Death()
    {
        print("You died!");
    }
}