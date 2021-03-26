using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public GameObject target;
    public GameObject character_car;

    float rotate_Distance;
    float car_Distance;

    private void Start()
    {
        //pos (660,110,5) rot (25,0,0)
        car_Distance = Vector3.Distance(character_car.transform.position, transform.position);
        
        //pos (250,65,30) rot (25,0,0)
        rotate_Distance = Vector3.Distance(target.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //if camera is a child of the centre point
        //transform.Rotate(0, cameraSpeed * Time.deltaTime, 0);
        
        //if camera is on its own
        //transform.RotateAround(target.transform.position, Vector3.up, cameraSpeed * Time.deltaTime);

        //using vector calculation
        //transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        //transform.LookAt(target.transform);
        //what does this one mean.. hmmm
        //transform.localPosition = target.transform.position - transform.forward * myDistance;

    }

    private void LateUpdate()
    {
        transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime);
        transform.localPosition = character_car.transform.position - transform.forward * car_Distance;
    }
}
