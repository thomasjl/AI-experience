using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pike : MonoBehaviour {

    private AudioSource audio;
    private GameObject gameManager;
    private GameObject player;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.Play();
            MonoBehaviour scriptPlayer = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            scriptPlayer.enabled = false;
            StartCoroutine("PlayerDie");
        }
    }

    IEnumerator PlayerDie()
    {
        yield return new WaitForSeconds(2);
        gameManager.GetComponent<GameManager>().playerDie();
    }
}
