using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{

    public float forceToApply = -2.0f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();


        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //f = ma so a = f/m
        Vector3 force = new Vector3(0, 0 , 0);
        force.z = forceToApply / rb.mass;
        rb.MovePosition(force * Time.fixedDeltaTime);
    }
}
