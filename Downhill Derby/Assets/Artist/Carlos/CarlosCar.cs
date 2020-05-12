using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(InputManager))]
public class CarlosCar : MonoBehaviour
{
    public WheelCollider[] WC;
    public GameObject [] Wheels;
    public float torque = 200;
    public float MaxSteerAngle = 30;
   // public  InputManager  im;
    


    // Start is called before the first frame update
    void Start()
    {
     //   im = GetComponent<InputManager>();
    }

    void Go(float accel, float steer)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * MaxSteerAngle;
        float thrustTorque = accel * torque;

        for (int i = 0; i < 4; i++)
        {
            WC[i].motorTorque = thrustTorque;
            if(i<2)
               WC[i].steerAngle = steer;

            Quaternion quat;
            Vector3 position;
            WC[i].GetWorldPose(out position, out quat);
            Wheels[i].transform.rotation = quat;
            Wheels[i].transform.position = position;
        }
    }


    // Update is called once per frame
    void Update()
    {
        float a = Input.GetAxis("Vertical");

        float sb = Input.GetAxis("Horizontal");
        Go(a,sb);
    }
}
