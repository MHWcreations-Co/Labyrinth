using UnityEngine;

public class CharacterFollower : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 1.0f)] private float smoothnessPositionStrength = 0.125f;
    [SerializeField] [Range(0.0f, 1.0f)] private float smoothnessRotationStrength = 0.3f;

    //[SerializeField] private Vector3 offset = new Vector3(0, 2.5f, -4);

    private GameObject _player;
    private Vector3 _playerPosition;
    private Quaternion _playerRotation;
    private Vector3 _editedPlayerPosition;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        _playerPosition = _player.transform.position;
        _playerRotation = _player.transform.localRotation;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, _playerPosition, smoothnessPositionStrength);
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, _playerRotation, smoothnessRotationStrength);

        var transform1 = transform;
        transform1.position = smoothedPosition;
        transform1.rotation = smoothedRotation;

        //transform.LookAt(_player.transform);
    }
}