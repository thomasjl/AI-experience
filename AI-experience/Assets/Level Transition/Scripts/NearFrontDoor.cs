using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NearFrontDoor : MonoBehaviour {

    public GameObject gameManager;
    public Text nextLevelText;

    void Start()
    {
        nextLevelText.enabled = false;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            nextLevelText.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                gameManager.GetComponent<GameManagerLevelTransition>().playNextLevel();
            }

        }

    }

    void OnTriggerExit( Collider other)
    {
        if (other.tag == "Player")
        {
            nextLevelText.enabled = false;
        }
    }
}
