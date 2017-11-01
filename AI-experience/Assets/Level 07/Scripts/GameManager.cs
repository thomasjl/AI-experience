using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Vector3 playerRespawn;

    private GameObject player;

    private Vector3 startPositionPlayer;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRespawn = player.transform.position;
        startPositionPlayer = player.transform.position;
    }

    void Update()
    {
        
    }

    public void playerDie()
    {
        player.transform.position = playerRespawn;
        MonoBehaviour scriptPlayer = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        scriptPlayer.enabled = true;
    }


}
