using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float characterSpeed = 6.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float sensitivity = 50;

    private Vector3 _moveDirection = Vector3.zero;
    private float _moveIndicator;

    //public GameObject cameraObject;

    private UnityEngine.CharacterController _characterController;
    private Animator anim;

    private float _rotationX = 0;

    void Awake()
    {
        _characterController = gameObject.GetComponent<UnityEngine.CharacterController>();
        anim = gameObject.transform.GetChild(2).gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        PlayerRotation();

        CharacterControllerPlayerMovement();
    }

    private void PlayerRotation()
    {
        _rotationX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime * 2.25f;
        //float rotationY = Input.GetAxis("Mouse Y") * 100 * Time.deltaTime * (-1.25f);

        transform.Rotate(0, _rotationX, 0);

        //tmp = Mathf.Clamp(PositionOperations.ToFloat(rotationY), -100, 100);
        //Debug.Log("tmp: " + tmp);
        //
        //float rotationYFloat = rotationY;
        //
        //
        // if (cameraObject.transform.rotation.eulerAngles.x >= 30.0f
        //     && cameraObject.transform.rotation.eulerAngles.x <= 330.0f)
        // {
        //     if (cameraObject.transform.rotation.eulerAngles.x <= 180.0f)
        //     {
        //         if (rotationYFloat < 0)
        //         {
        //             cameraObject.transform.Rotate(rotationYFloat, 0, 0);
        //         }
        //     }
        //     else
        //     {
        //         if (rotationYFloat > 0)
        //         {
        //             cameraObject.transform.Rotate(rotationYFloat, 0, 0);
        //         }
        //     }
        // }
        // else
        // {
        //     cameraObject.transform.Rotate(rotationYFloat, 0, 0);
        // }
    }

    private void CharacterControllerPlayerMovement()
    {
        if (_characterController.isGrounded)
        {
            _moveDirection = Vector3.zero;

            // right
            _moveDirection += transform.right * Input.GetAxis("Horizontal");

            // forward
            _moveDirection += transform.forward * Input.GetAxis("Vertical");

            _moveDirection *= characterSpeed;

            if (Input.GetButton("Jump"))
            {
                _moveDirection.y = jumpSpeed;
            }
        }

        _moveDirection.y -= gravity * Time.fixedDeltaTime;

        _characterController.Move(_moveDirection * Time.fixedDeltaTime);

        _moveIndicator = Mathf.Abs(_moveDirection.x) + Mathf.Abs(_moveDirection.z);

        anim.SetFloat("Walk", _moveIndicator);
    }
}