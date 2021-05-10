using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region PUBLIC FIELDS
    [Header(header: "Walk / Run Setting")]
    public float walkSpeed;
    public float runSpeed;

    [Header(header: "Jump Setting")]
    public float playerJumpForce;
    public ForceMode appliedForceMode;

    [Header(header: "Jumping State")]
    public bool playerIsJumping;

    [Header(header: "Current Player Speed")]
    public float currentSpeed;

    [Header(header: "Camera Offset")]
    public Vector3 Offset;

    #endregion

    #region PRIVATE FIELDS

    private float _xAxis;
    private float _zAxis;
    private RaycastHit _hit;
    private Vector3 _groundLocation;
    private bool _isCapslockPressedDown;
    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;


    [Header(header: "Serialized Fields")]
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private FixedJoystickButton _joyStickButton;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _anim;
    [SerializeField] private Camera _mainCamera;

    #endregion

    #region MONODEVELOP ROUTINES

    private void Start()
    {
        #region Initializing Components

        #endregion
    }

    private void Update()
    {
        #region Controller Input

        _xAxis = _joystick.Horizontal;
        _zAxis = _joystick.Vertical;

        #endregion

        #region Animation Update

        if (_anim != null)
        {
            if (new Vector2(_xAxis, _zAxis).magnitude > 0.1f)
                _anim.SetBool("IsMoving", true);
            else
                _anim.SetBool("IsMoving", false);
        }

        #endregion
    }

    private void FixedUpdate()
    {
        #region Player Movement

        if (_joystick.Direction.magnitude > 0.1f)
        {
            //direction the player is moving
            Vector3 direction = new Vector3(_xAxis, 0f, _zAxis).normalized;

            // this gives us the angle that the player needs to rotate to to face their movement
            float targetAngle = Mathf.Atan2(_xAxis, _zAxis) * Mathf.Rad2Deg;

            // this will allow us to smoothly move from our current rotation to the target rotation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

            //apply the smoothed out rotation to player
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // the player moves in the direction that they are facing
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            _rb.MovePosition(transform.position + (moveDir.normalized * currentSpeed * Time.fixedDeltaTime));
        }

        #endregion
    }

    private void LateUpdate()
    {
        _mainCamera.transform.position = transform.position + Offset;
        _mainCamera.transform.rotation = Quaternion.LookRotation(-Offset);
    }

    #endregion

    #region HELPER ROUTINES

    private void PlayerJump()
    {

    }

    #endregion
}

/* public class PlayerMovement : MonoBehaviour
{
     public CharacterController cc;
    //public Transform cam;
    //public Rigidbody rb;
    public Animator anim;

    public float speed;
    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;
    Vector3 movement;

    //Mobile Inputs
    [SerializeField]
    private FixedJoystick joystick;
    [SerializeField]
    private FixedJoystickButton joyStickButton;

    // Update is called once per frame
    void Update()
    {
        //check for input
        //movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        movement = new Vector3(joystick.Vertical, 0f, -joystick.Horizontal);

        if (anim != null)
        {
            //send animation
            if (movement.magnitude >= 0.1f)
                anim.SetBool("IsMoving", true);
            else
                anim.SetBool("IsMoving", false);
        }

        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + movement.magnitude; //cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            cc.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            Debug.Log("Hit Enemy");

            if(anim != null)
            {
                anim.SetTrigger("Hit");
            }
        }
    }
}
*/