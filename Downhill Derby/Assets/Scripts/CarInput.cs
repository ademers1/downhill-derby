using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInput : MonoBehaviour
{

    float turningAcceleration = 1;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 sidewaysTurning = new Vector3();
            sidewaysTurning.x = -turningAcceleration;
            rb.AddForce(sidewaysTurning);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 sidewaysTurning = new Vector3();
            sidewaysTurning.x = turningAcceleration;
            rb.AddForce(sidewaysTurning);            
        }
    }
}
