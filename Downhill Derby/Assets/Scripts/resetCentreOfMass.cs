using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetCentreOfMass : MonoBehaviour
{
    public Vector3 com;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        rb.centerOfMass = com;
    }

    private void Update()
    {
        rb.AddForce(0, 0, 0);
    }

}
