using UnityEngine;

public class FollowerMovement : MonoBehaviour
{
    [SerializeField] private float smoothSpeed = 0.125f;

    [SerializeField] private Vector3 offset;

    private GameObject _player;
    private Vector3 _playerPosition;
    private Vector3 _editedPlayerPosition;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        _playerPosition = _player.transform.position + offset;
        Vector3 desiredPosition = _playerPosition;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(_player.transform);
    }
}