using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FalleObject : MonoBehaviour
{
    [SerializeField] private int health = 3;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        health = health - 1;
        Debug.Log(health);
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}