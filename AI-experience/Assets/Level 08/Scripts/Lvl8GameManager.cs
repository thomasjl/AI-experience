using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl8GameManager : MonoBehaviour {

    public Vector3 checkpointPos;
    public Vector3 checkpointRot;

    private Rigidbody rbCamaro;


    void Start()
    {
        checkpointPos = GameObject.FindGameObjectWithTag("Camaro").gameObject.transform.position;
        checkpointRot = GameObject.FindGameObjectWithTag("Camaro").gameObject.transform.eulerAngles;

        rbCamaro = GameObject.FindGameObjectWithTag("Camaro").gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("return pressed");
            rbCamaro.velocity = Vector3.zero;
            GameObject.FindGameObjectWithTag("Camaro").transform.position = checkpointPos;
            GameObject.FindGameObjectWithTag("Camaro").transform.eulerAngles = checkpointRot;

        }
    }

}
