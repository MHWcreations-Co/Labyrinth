using UnityEngine;

public class IfPlayerFallenDownChecker : MonoBehaviour
{
    [SerializeField] private Vector3 underWorld = new Vector3(0, -3, 0);

    void Start()
    {
        InvokeRepeating(nameof(DeathChecker), 0, 1);
    }

    private void DeathChecker()
    {
        if (!(gameObject.transform.position.y < underWorld.y)) return;
        DeathOperations.KillTarget(PlayerManager.Player);
    }
}