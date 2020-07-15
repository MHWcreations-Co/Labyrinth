using UnityEngine;

public class DeathManager : MonoBehaviour
{
    [SerializeField] private Vector3 underWorld = new Vector3(0, -3, 0);

    void Start()
    {
        InvokeRepeating("DeathChecker", 0, 1);
    }

    private void DeathChecker()
    {
        if (gameObject)
        {
            if (!(gameObject.transform.position.y < underWorld.y)) return;
            Debug.Log("player died");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No player detected!");
        }
    }
}