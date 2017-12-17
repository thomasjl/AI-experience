using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchWater : MonoBehaviour {

    public GameObject water;
    public GameObject waterInstance;

    private bool hasBeenPushed;

    void Start()
    {
        hasBeenPushed = false;
    }

    void OnCollisionEnter( Collision collision)
    {
        if (collision.gameObject.tag == "Camaro" && hasBeenPushed==false)
        {
            //Debug.Log("percussion");
            waterInstance = Instantiate(water, transform.position, Quaternion.identity);
            hasBeenPushed = true;
        }
      
    }
}
