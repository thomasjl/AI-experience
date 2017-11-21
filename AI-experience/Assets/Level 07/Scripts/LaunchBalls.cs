using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBalls : MonoBehaviour {


    public GameObject ball;
    public GameObject ballLaunchedPoint;


	
    public bool ballLaunched;

    void Start()
    {
        ballLaunched = false;
    }
        
   

    void OnTriggerEnter()
    {
        if (!ballLaunched)
        {
            Instantiate(ball, ballLaunchedPoint.transform.position, Quaternion.identity);
            ballLaunched = true;
        }
    }

    public void LaunchBall()
    {
        Instantiate(ball, ballLaunchedPoint.transform.position, Quaternion.identity);
        ballLaunched = true;
    }
}
