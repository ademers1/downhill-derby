using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carDestruction : MonoBehaviour
{
    public GameObject car;
    public GameObject[] destroyedCarPart;
    int childIndexRange = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if(childIndexRange>1)
        {
            Debug.Log("obstacle hit");
            if (collision.gameObject.tag =="Obstacles")
            {
                int childIndex = Random.Range(1,childIndexRange+1);
                childIndexRange--;
                if(childIndexRange == 1)
                {
                    childIndex = 1;
                }
                GameObject child = car.transform.GetChild(childIndex).gameObject;
                Instantiate(destroyedCarPart[childIndex-1], child.transform.position, child.transform.rotation);
                Destroy(child);
            }

        }
    }
    
}
