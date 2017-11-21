using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTask : MonoBehaviour {

    public bool FirstEnter;

    public bool goToLeft;
    public bool goToRight;

    private GameObject leftPike;
    private GameObject rightPike;

    void Start ()
    {
        FirstEnter = true;
        leftPike = GameObject.FindGameObjectWithTag("LeftPike");
        rightPike = GameObject.FindGameObjectWithTag("RightPike");
    }

    void OnTriggerEnter (Collider other)
    {
        if (!FirstEnter)
        {
            if (goToLeft)
            {
                leftPike.GetComponent<PikesController>().isActivated = true;
                rightPike.GetComponent<PikesController>().isActivated = false;
            }
            else
            {
                rightPike.GetComponent<PikesController>().isActivated = true;
                leftPike.GetComponent<PikesController>().isActivated = false;
            }
        }

    }

}
