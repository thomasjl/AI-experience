using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public GameObject lvl8GameManager; 

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Camaro")
        {
            Debug.Log("reached checkpoint");
            lvl8GameManager.GetComponent<Lvl8GameManager>().checkpointPos = transform.position;
            lvl8GameManager.GetComponent<Lvl8GameManager>().checkpointRot = transform.eulerAngles;
        }
    }



}
