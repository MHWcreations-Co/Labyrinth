using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrapScript : MonoBehaviour
{
    [SerializeField] private int health = 3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
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