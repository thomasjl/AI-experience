using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    private GameObject player;

    private bool onLadder;
    private float startSpeed;
   

    void Start()
    {     
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            if (player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>()!=null)
            {
                startSpeed = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed;
            }
        }



    }

    void Update()
    {     
        if(onLadder)
        {
            
            Debug.Log("vertical detected");
            player.transform.Translate(Vector3.up*Time.deltaTime*3, Space.World);    
        }
    }
	
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            onLadder = true;
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            //player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = 0f;
            //player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed = 0f;

           
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            //player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = startSpeed;
            onLadder = false;
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;

            GetComponent<BoxCollider>().isTrigger = false;//au bout de 5s, redevient trigger
            StartCoroutine("resetTrigger");
        }
            
    }

    IEnumerator resetTrigger()
    {
        yield return new WaitForSeconds(5);
        GetComponent<BoxCollider>().isTrigger = true;
    }
}
