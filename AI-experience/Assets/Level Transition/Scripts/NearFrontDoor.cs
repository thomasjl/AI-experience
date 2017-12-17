using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NearFrontDoor : MonoBehaviour {

    public GameObject gameManager;
    public Text nextLevelText;

    private bool canGoToNextLevel;

    void Start()
    {
        nextLevelText.enabled = false;
        canGoToNextLevel = false;
    }

    void Update()
    {
        if (canGoToNextLevel && Input.GetKeyDown(KeyCode.E))
        {
            gameManager.GetComponent<GameManagerLevelTransition>().playNextLevel();
        }

    }
        

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            nextLevelText.enabled = true;
            canGoToNextLevel = true;

        }

    }

    void OnTriggerExit( Collider other)
    {
        if (other.tag == "Player")
        {
            nextLevelText.enabled = false;
            canGoToNextLevel = false;
        }
    }
}
