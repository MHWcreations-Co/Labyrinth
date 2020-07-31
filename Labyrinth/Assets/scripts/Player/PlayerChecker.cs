using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChecker : MonoBehaviour
{
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}