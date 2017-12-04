using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    public GameObject pointToRotateOn;
    public float speed;   

    private AudioSource audio;
    private GameObject player;
    private GameObject gameManager;
    private GameObject fourthTask;

    void Start()
    {
        transform.RotateAround(pointToRotateOn.transform.position, Vector3.up, Time.deltaTime*speed);
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        fourthTask = GameObject.FindGameObjectWithTag("FourthTask");
    }

    void Update()
    {
        transform.RotateAround(pointToRotateOn.transform.position, Vector3.up, Time.deltaTime*speed);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            Debug.Log("being electrocuted");
            audio.Play();
            MonoBehaviour scriptPlayer = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            scriptPlayer.enabled = false;
            StartCoroutine("PlayerDie");

            fourthTask.GetComponent<DisableFourthTask>().attemptNumber++;

        }
    }

    IEnumerator PlayerDie()
    {
        yield return new WaitForSeconds(2);
        gameManager.GetComponent<GameManager>().playerDie();
    }




}
