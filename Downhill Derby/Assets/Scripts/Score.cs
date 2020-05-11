using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    float scoreMultiplier = 1f;
    float score;
    public GameObject Player;
    public Text txtScore;
    int oldScore;
    // Start is called before the first frame update
    void Start()
    {
        oldScore = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        score += Player.GetComponent<Rigidbody>().velocity.magnitude * scoreMultiplier;
        if(score / 100 > oldScore)
        {
            oldScore = (int) score/100;

            txtScore.text = "Score: " + oldScore.ToString() + "00";
            
        }
    }
}
