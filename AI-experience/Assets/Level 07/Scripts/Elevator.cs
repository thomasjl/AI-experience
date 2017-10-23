﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public float elevationSpeed;
    public GameObject parentToPlayer;

    public  bool inside;
    private bool goUp;
    private bool goDown;
    public bool doorClosed;

    private Vector3 downPosition;
    private Vector3 upPosition;

    public GameObject door;

    public bool arrived;

    void Start ()
    {
        inside = false;
        goUp = false;
        goDown = false;
        doorClosed = true;

        downPosition = transform.position;
        upPosition = transform.position + new Vector3(0, 15f, 0);
        arrived = false;

    }

    void Update()
    {
        if (inside && goUp && doorClosed)
        {
            // ascenseur monte
            transform.position = Vector3.Lerp(transform.position, upPosition, elevationSpeed * Time.deltaTime);

            float distance = Vector3.Distance(transform.position, upPosition);
            if (distance <= 0.1f)
            {
                goUp = false;
                //ouverture de la porte, tant que le joueur n'est pas sortie
                door.GetComponent<Door>().openning = true;

                //joueur n'est plus fils
                GameObject.FindGameObjectWithTag("Player").transform.parent=null;

                arrived = true;
            }          


        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
           
            inside = true;
            // player est enfant de l'elevator, pour qu'il se deplace avec lui (sinon, saccade)

            other.gameObject.transform.parent = parentToPlayer.transform;
            //Vector3 tempRot = other.transform.localEulerAngles + new Vector3(0, 180f, 0);
            //other.transform.localEulerAngles = tempRot;

            goUp = true;
        }
       
    }

}