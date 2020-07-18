using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float characterSpeed = 6.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private float sensitivityX = 50;
    [SerializeField] private float sensitivityY = 20;
    [SerializeField] private float clampTop = 1500;
    [SerializeField] private float clampBottom = 20;
    [SerializeField] private bool cameraFixed = true;

    private Vector3 _moveDirection = Vector3.zero;
    private float _moveIndicator;

    //public GameObject cameraObject;

    private UnityEngine.CharacterController _characterController;
    private Animator _anim;
    private GameObject _camera;

    private float _rotationX = 0;
    private float _rotationY = 0;

    void Awake()
    {
        _characterController = gameObject.GetComponent<UnityEngine.CharacterController>();
        _anim = gameObject.transform.GetChild(2).gameObject.GetComponent<Animator>();

        if (Camera.main != null) _camera = Camera.main.gameObject;
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
        _rotationX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        _rotationY = Input.GetAxis("Mouse Y") * -sensitivityY * Time.deltaTime;

        transform.Rotate(0, _rotationX, 0);

        if (cameraFixed) return;
        if (_camera.transform.rotation.eulerAngles.x >= clampBottom
            && _camera.transform.rotation.eulerAngles.x <= clampTop)
        {
            if (_camera.transform.rotation.eulerAngles.x <= 180.0f)
            {
                if (_rotationY < 0)
                {
                    _camera.transform.Rotate(_rotationY, 0, 0);
                }
            }
            else
            {
                if (_rotationY > 0)
                {
                    _camera.transform.Rotate(_rotationY, 0, 0);
                }
            }
        }
        else
        {
            _camera.transform.Rotate(_rotationY, 0, 0);
        }
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

        _anim.SetFloat("Walk", _moveIndicator);
    }
}