using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] [Range(0, 128)] private float jumpSpeed = 10f; // jumpSpeed variable
    [SerializeField] private string noJumpTag = "noJump";

    private bool _isGrounded = false;
    private int _isGroundedInt;

    private Vector3 _movement;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Animator _animator;
    private Character _character;
    private Camera _camera;
    private static readonly int Walk = Animator.StringToHash("Walk");

    private void Awake()
    {
        _character = GetComponent<Character>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _camera = Camera.main;
    }

    private void Update()
    {
        _isGroundedInt = _isGrounded ? 1 : 0;

        // float lh = Input.GetAxis("Horizontal");
        // float lv = Input.GetAxis("Vertical");

        // float jumpValue =
        //     _rigidbody.velocity.y + (Input.GetAxis("Jump") * _isGroundedInt * jumpSpeed);

        //moveInput = new Vector3(lh, 0, lv);


        _movement = new Vector3(Input.GetAxis("Horizontal") * _character.Speed, _rigidbody.velocity.y - 1,
            Input.GetAxis("Vertical") * _character.Speed);

        // Vector3 cameraForward = _camera.transform.forward;
        // cameraForward.y = 0;

        // moveVelocity = transform.forward;

        //moveVelocity = transform.forward * _character.Speed * moveInput.sqrMagnitude;
        
        Vector3 velocity = _rigidbody.velocity;
        _animator.SetFloat(Walk, new Vector2(velocity.x, velocity.z).magnitude);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _movement; //todo: Time.DeltaTime
        // _rigidbody.velocity = moveVelocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        _isGrounded = !other.gameObject.CompareTag(noJumpTag);
    }

    private void OnCollisionExit(Collision other)
    {
        _isGrounded = false;
    }
}