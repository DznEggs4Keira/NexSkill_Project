using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cc;
    //public Transform cam;
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
        movement = new Vector3(joystick.Horizontal, 0f, joystick.Vertical).normalized;

        Debug.Log("x: " + movement.x + " z: " + movement.z);

        //send animation
        if(movement != Vector3.zero)
            anim.SetBool("IsMoving", true);
        else
            anim.SetBool("IsMoving", false);

        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + movement.sqrMagnitude; //cam.eulerAngles.y;
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

            anim.SetTrigger("Hit");
        }
    }
}
