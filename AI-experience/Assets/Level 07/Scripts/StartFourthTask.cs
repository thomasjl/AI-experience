using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFourthTask : MonoBehaviour {

    public GameObject ligthning1;
    public GameObject ligthning2;
    public GameObject ligthning3;

    private bool hasEverEntered;

    void Start()
    {
        ligthning1.SetActive(false);
        ligthning2.SetActive(false);
        ligthning3.SetActive(false);

        hasEverEntered = false;
    }

    void OnTriggerEnter( Collider other)
    {
        if (other.tag == "Player")
        {
            if (!hasEverEntered)
            {
                ligthning1.SetActive(true);
                ligthning2.SetActive(true);
                ligthning3.SetActive(true);
            }

        }
    }

}
