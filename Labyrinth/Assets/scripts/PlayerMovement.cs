using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rig; // Rigidbody variable

    [SerializeField] private float speed = 0.5f; // speed variable
    [SerializeField] private float jumpSpeed = 10f; // jumpSpeed variable

    private float _valueUp = 0f; // the Y-axis value 
    private const float AdditionalGravity = 0.05f; // additionalGravity when the player is in air
    [SerializeField] private string noJump = "noJump";

    [SerializeField] private KeyCode keyUp = KeyCode.Space; // Jump key

    private void Awake()
    {
        _rig = GetComponent<Rigidbody>(); // we are assigning the Rigidbody too over variable 
    }

    private void OnCollisionStay(Collision other)
    {
        if (!other.collider.CompareTag(noJump)) // if not noJump that player can jump
        {
            _valueUp = Input.GetKey(keyUp) ? 1 : 0; // when keyUp is pressed the _upValue = 1, when not = 0
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _valueUp =
            -AdditionalGravity; // when the player is not colliding with an object than the force is -AdditionalGravity
    }

    private void FixedUpdate()
    {
        _rig.velocity += new Vector3(Input.GetAxis("Horizontal"), _valueUp * jumpSpeed, Input.GetAxis("Vertical")) *
                         speed; // here we are executing all forces
    }
}