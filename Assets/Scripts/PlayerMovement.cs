using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region PUBLIC FIELDS
    [Header(header: "Walk / Run Setting")]
    public float walkSpeed;
    public float runSpeed;

    [Header(header: "Current Player Speed")]
    public float currentSpeed;

    [Header(header: "Camera Offset")]
    public Vector3 Offset;

    #endregion

    #region PRIVATE FIELDS

    private float _xAxis;
    private float _zAxis;
    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;

    protected float CameraAngle = 0f;
    protected float CameraAngleSpeed = 0.2f;

    [Header(header: "Serialized Fields")]
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private FixedTouchField _camField;
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

        #region Camera Update

        // calculate angle of camera
        CameraAngle += _camField.TouchDist.x * CameraAngleSpeed;

        //set rotationa and position of camera
        _mainCamera.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * Offset;

        //look rotation of the camera - it should always look at the player
        _mainCamera.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - _mainCamera.transform.position, Vector3.up);

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
            float targetAngle = Mathf.Atan2(_xAxis, _zAxis) * Mathf.Rad2Deg + _mainCamera.transform.eulerAngles.y;

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

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Enemies"))
        _anim.SetTrigger("Hit");

        _rb.velocity = Vector3.zero;
    }

    #endregion
}