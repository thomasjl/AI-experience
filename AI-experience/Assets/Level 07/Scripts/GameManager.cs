using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject player;

    private Vector3 startPositionPlayer;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPositionPlayer = player.transform.position;
    }

    void Update()
    {
        
    }

    public void playerDie()
    {
        player.transform.position = startPositionPlayer;
        MonoBehaviour scriptPlayer = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        scriptPlayer.enabled = true;
    }


}
