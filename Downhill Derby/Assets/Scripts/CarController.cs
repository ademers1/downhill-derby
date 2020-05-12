using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public InputManager im;
    public List<WheelCollider> throttleWheels;
    public List<GameObject> steeringWheels;
    public List<GameObject> meshes;
    public float strengthCoefficient = 20000f;
    public float maxTurn = 0.1f;
    public Transform CM;
    public Rigidbody rb;
    float engineSpeedSound;
    public float currentStrength;
    public float Turbo;
    public float TurboTime;
    // Start is called before the first frame update
    void Start()
    {
        currentStrength = strengthCoefficient;
        im = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();

        if (CM)
        {
           // rb.centerOfMass = CM.localPosition;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      

        if (rb.velocity.magnitude > 100)
        {
            engineSpeedSound = 100;

        }
        else
        {
            engineSpeedSound = rb.velocity.magnitude;
        }
        AkSoundEngine.SetRTPCValue("driveSpeed", engineSpeedSound);
        foreach (WheelCollider wheel in throttleWheels)
        {
            wheel.motorTorque = strengthCoefficient * Time.fixedDeltaTime * im.throttle;
        }
        foreach(GameObject wheel in steeringWheels)
        {
            wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * im.steer;
            wheel.transform.localEulerAngles = new Vector3(0f, im.steer * maxTurn, 0f);
        }
        foreach (GameObject mesh in meshes)
        {
            mesh.transform.Rotate(mesh.transform.right * rb.velocity.magnitude / (2 * Mathf.PI * 0.08f) , 0f, 0f);
        }

        
    
    
    }

    private void Booster()
    {
        strengthCoefficient=currentStrength;
    }

    private void OnTriggerEnter(Collider other)
    {
        strengthCoefficient = currentStrength * Turbo;
        Invoke("Booster", TurboTime);



    }












}
