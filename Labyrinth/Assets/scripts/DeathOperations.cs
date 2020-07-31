using UnityEngine;

public class DeathOperations : MonoBehaviour
{
    public static void KillTarget(GameObject target)
    {
        Destroy(target);
    }
}