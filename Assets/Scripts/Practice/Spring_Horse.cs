using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring_Horse : MonoBehaviour
{
    public Rigidbody Horse;

    // Start is called before the first frame update
    void Start()
    {
        Horse.AddForce(Vector3.up, ForceMode.Impulse);  
    }

    // Update is called once per frame
    void Update()
    {
    }
}
