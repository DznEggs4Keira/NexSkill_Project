using UnityEngine;

public class FreeCam : MonoBehaviour
{
    float flySpeed = 10.0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Vector3.forward * flySpeed * Input.GetAxis("Vertical"));
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * flySpeed * Input.GetAxis("Horizontal"));
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.up * flySpeed);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.down * flySpeed);
        }
    }
}
