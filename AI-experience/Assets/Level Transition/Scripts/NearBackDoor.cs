using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NearBackDoor : MonoBehaviour {

    public GameObject gameManager;
    public Text replayText;

    void Start()
    {
        replayText.enabled = false;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            replayText.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                gameManager.GetComponent<GameManagerLevelTransition>().replayLevel();
            }

        }

    }

    void OnTriggerExit( Collider other)
    {
        if (other.tag == "Player")
        {
            replayText.enabled = false;
        }
    }

}
