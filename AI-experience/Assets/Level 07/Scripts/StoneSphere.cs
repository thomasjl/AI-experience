using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSphere : MonoBehaviour {

    private GameObject gameManager;
    private GameObject player;

    private GameObject task;
	
    public bool touchPlayer;

    void Start()
    {       
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
        task = GameObject.FindGameObjectWithTag("BallManager");

        touchPlayer = false;
    }

    void OnTriggerEnter( Collider other)
    {
        if (other.tag == "Player")
        {            
            MonoBehaviour scriptPlayer = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            scriptPlayer.enabled = false;
            StartCoroutine("PlayerDie");
        }
    }

    IEnumerator PlayerDie()
    {      
        task.GetComponent<LaunchBalls>().ballLaunched = false;
        touchPlayer = true;

        yield return new WaitForSeconds(2);

        gameManager.GetComponent<GameManager>().playerDie();
       

        Destroy(gameObject);
    }
}
