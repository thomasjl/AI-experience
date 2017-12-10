using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToStarPosition : MonoBehaviour {

    private Vector3 startPos;
    private Vector3 startRot;


    private GameObject gameManager;

    private bool goToStartPos;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.eulerAngles;

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        Debug.Log("start pos : " + transform.position.x);
        goToStartPos = false;
    }


    void Update()
    {
        if (gameManager.GetComponent<Lvl8GameManager>().returnToCheckpoint && !goToStartPos)
        {
            goToStartPos = true;

            StartCoroutine("setBooleanToFalse");

            Debug.Log("return to start position");

            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = startPos;

            Debug.Log("starttransform apres : " + startPos.x);
            transform.eulerAngles = startRot;


        }

    }

    IEnumerator setBooleanToFalse()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody>().isKinematic = false;

        this.enabled = false;
        goToStartPos = false;

    }
}
