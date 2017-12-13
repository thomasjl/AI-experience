using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lvl8GameManager : MonoBehaviour {

    public Vector3 checkpointPos;
    public Vector3 checkpointRot;

    public Text damageTakenText;
    public Text speedText;

    private Rigidbody rbCamaro;

    public int damageTaken;

    public bool returnToCheckpoint;

    void Start()
    {
        checkpointPos = GameObject.FindGameObjectWithTag("Camaro").gameObject.transform.position;
        checkpointRot = GameObject.FindGameObjectWithTag("Camaro").gameObject.transform.eulerAngles;

        rbCamaro = GameObject.FindGameObjectWithTag("Camaro").gameObject.GetComponent<Rigidbody>();
        damageTaken = 0;
        returnToCheckpoint = false;
    }

    void Update()
    {
        speedText.text = Mathf.Abs(Mathf.Round(rbCamaro.velocity.z * 3.6f)) + "";

        damageTakenText.text = "Dégâts reçus : " + damageTaken;

        // revient au dernier checkpoint, quand press "entrée"
        if (Input.GetKeyDown(KeyCode.Return))
        {
            damageTaken = 0;
            Debug.Log("return pressed");
            returnToLastCheckpoint();

        }


        // si percute trop d'obstacle, retourne au dernier checkpoint
        if (damageTaken >= 10)
        {
            returnToLastCheckpoint();
            damageTaken = 0;
        }

    }


    void returnToLastCheckpoint()
    {
        returnToCheckpoint = true;

        StartCoroutine("setBooleanToFalse");

        rbCamaro.velocity = Vector3.zero;
        GameObject.FindGameObjectWithTag("Camaro").transform.position = checkpointPos;
        GameObject.FindGameObjectWithTag("Camaro").transform.eulerAngles = checkpointRot;
    }


    IEnumerator setBooleanToFalse()
    {
        yield return new WaitForSeconds(1);
        returnToCheckpoint = false;

    }

}
