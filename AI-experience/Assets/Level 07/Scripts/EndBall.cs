﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBall : MonoBehaviour {

    public GameObject task;

    void Start()
    {


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StoneSphere")
        {
            if (!other.gameObject.GetComponent<StoneSphere>().touchPlayer)
            {
                task.GetComponent<LaunchBalls>().LaunchBall();
                Destroy(other.gameObject);
            }

        }
    }


}
