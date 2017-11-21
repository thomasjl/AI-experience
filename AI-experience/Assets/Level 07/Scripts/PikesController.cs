using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikesController : MonoBehaviour {

    public GameObject pikes;
    public float speedUp;
    public float speedDown;


    private AudioSource audio;

    public float downY;
    public float upY;
   
    private bool beginTranslation;

    private Vector3 dest;
    private Vector3 initPos;

    private GameObject player;
   
    public bool isActivated;

    private GameObject parent;
    private GameObject gameManager;

    private bool isUp;
    private bool goDown;

    void Start ()
    {
        downY = -0.67f;
        upY = 0.558f + 0.67f;

        beginTranslation = false;
        initPos = pikes.transform.position;

        dest = pikes.transform.position + new Vector3(0, upY, 0);
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        isActivated = false;

        parent = gameObject.transform.parent.gameObject;
        isUp = false;
        goDown = false;
    }

    void Update ()
    {

        if (beginTranslation)
        {
            pikes.transform.position = Vector3.Lerp(pikes.transform.position, dest, speedUp * Time.deltaTime);
            isUp = true;

        }
        else if (goDown)
        {
            Debug.Log("go down");
            pikes.transform.position = Vector3.Lerp(pikes.transform.position, initPos, speedDown * Time.deltaTime);
            isUp = false;
        }
           
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {           
            

            if (parent.GetComponent<FirstTask>().FirstEnter)
            {
                if (tag == "LeftPike")
                {
                    parent.GetComponent<FirstTask>().goToLeft = true;
                    parent.GetComponent<FirstTask>().goToRight = false;
                }
                else
                {
                    parent.GetComponent<FirstTask>().goToLeft = false;
                    parent.GetComponent<FirstTask>().goToRight = true;
                }

                parent.GetComponent<FirstTask>().FirstEnter = false;

                //au premier passage, se declenche dans les deux cas
                beginTranslation = true;
                audio.Play();
                MonoBehaviour scriptPlayer = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
                scriptPlayer.enabled = false;
                StartCoroutine("PlayerDie");

            }
            else
            {
                //passages suivant, doit aller dans l'autre passage que celui du premier
                if (isActivated)
                {
                    beginTranslation = true;
                    audio.Play();
                    MonoBehaviour scriptPlayer = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
                    scriptPlayer.enabled = false;
                    StartCoroutine("PlayerDie");

                }
            }
           
        }
    }   

    IEnumerator PlayerDie()
    {
        yield return new WaitForSeconds(2);
        gameManager.GetComponent<GameManager>().playerDie();
    }

    void OnTriggerExit ()
    {
        Debug.Log("exit pike");
        if (isUp)
        {
            beginTranslation = false;
            goDown = true;
            isUp = false;

        }
    }


}
