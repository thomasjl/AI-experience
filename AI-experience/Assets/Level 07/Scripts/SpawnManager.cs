using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject spawnSecondTask;
    private bool hasEverEntered;

    void Start()
    {
        hasEverEntered = false;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            if (!hasEverEntered)
            {
                hasEverEntered = true;
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().playerRespawn = spawnSecondTask.transform.position;
            }
        }

    }
}
