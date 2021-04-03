using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Controller : MonoBehaviour
{
    readonly float engineForce = 200000f;
    readonly float maxTurn = 20f;
    float throttle;
    float steering;

    public Rigidbody rb;

    public List<WheelCollider> Drive;
    public List<GameObject> Steering;
    public List<GameObject> Rims;

    // Update is called once per frame
    void FixedUpdate()
    {
        steering = Input.GetAxis("Horizontal");
        throttle = Input.GetAxis("Vertical");

        foreach(WheelCollider wheel in Drive)
        {
            wheel.motorTorque = engineForce * Time.fixedDeltaTime * throttle;
        }

        foreach (GameObject wheel in Steering)
        {
            wheel.GetComponentInChildren<WheelCollider>().steerAngle = maxTurn * steering;
            wheel.transform.localEulerAngles = new Vector3(0f, wheel.GetComponentInChildren<WheelCollider>().steerAngle, 90f);
        }

        foreach(GameObject rims in Rims)
        {
            //rotate wheels
            rims.transform.Rotate(0f, (rb.velocity.magnitude * (transform.InverseTransformDirection(rb.velocity).z >= 0 ? -1 : 1) /*/ (2f * Mathf.PI * 1.99f)*/), 0f);
        }
    }
}
