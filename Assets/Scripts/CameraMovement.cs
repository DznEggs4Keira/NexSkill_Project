using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public GameObject target;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, cameraSpeed * Time.deltaTime, 0);

        //transform.RotateAround(target.transform.position, Vector3.up, cameraSpeed * Time.deltaTime);
    }
}
