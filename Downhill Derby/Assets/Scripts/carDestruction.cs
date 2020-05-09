using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carDestruction : MonoBehaviour
{
    public GameObject parent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Obstacles")
        {
            parent.transform.GetChild(1).gameObject.transform.parent = null;
        }
    }
}
