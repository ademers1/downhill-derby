using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carDestruction : MonoBehaviour
{
    public GameObject car;
    public GameObject[] destroyedCarPart;
    Rigidbody rb;
    int childIndexRange = 3;
    float carHealth = 100;
    public Text healthText;
    public Queue<Color> healthColors = new Queue<Color>();
    Color Green = Color.green;
    Color GreenYellow = new Color(126/255, 255/255, 33/255);
    Color Yellow = Color.yellow;
    Color Orange = new Color(255/255, 118/255, 38/255);
    Color Red = Color.red;
    bool immune;

    private void Start()
    {
        if (!rb)
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
        healthText.color = Green;
        healthColors.Enqueue(GreenYellow);
        healthColors.Enqueue(Yellow);
        healthColors.Enqueue(Orange);
        healthColors.Enqueue(Red);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider);
        if(collision.collider.tag != "Road" && collision.collider.tag != "Wheel")
        {
            if (!immune)
            {
                takeDamage();
            }
        }


        StartCoroutine("Immunity");
        //if(childIndexRange > 1 & (carHealth <= 80 || carHealth <= 60 || carHealth <= 40 || carHealth <= 20) )
        //{
        //    Debug.Log("obstacle hit," + "current health = " + carHealth);
        //    if (collision.gameObject.tag =="Obstacles")
        //    {
        //        int childIndex = Random.Range(1,childIndexRange+1);
        //        childIndexRange--;
        //        if(childIndexRange == 1)
        //        {
        //            childIndex = 1;
        //        }
        //        GameObject child = car.transform.GetChild(childIndex).gameObject;
        //        Instantiate(destroyedCarPart[childIndex-1], child.transform.position, child.transform.rotation);
        //        Destroy(child);
        //    }

        //}
    }
    IEnumerator Immunity()
    {
        yield return new WaitForSeconds(5);
        immune = false;
    }

    void takeDamage()
    {
        immune = true;
        carHealth = carHealth - 20;
        healthText.color = healthColors.Dequeue();
        healthText.text = "Health: " + carHealth;
        
    }

}
