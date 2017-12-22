using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel8 : MonoBehaviour {

    private bool isOnEmplacement;
    public GameObject endUIToPrint;

    public bool printUi;

    void Start()
    {
        isOnEmplacement = false;
        endUIToPrint.SetActive(false);
        printUi = false;
    }

    void Update()
    {
        if (isOnEmplacement)
        {
            if (!printUi && GameObject.FindGameObjectWithTag("Camaro").gameObject.GetComponent<Rigidbody>().velocity.z <= 0.25)
            {
                Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
                printUi = true;
                Debug.Log("print ui end level 8");
                endUIToPrint.SetActive(true);
                GameObject.FindGameObjectWithTag("Camaro").gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Camaro")
        {
            Debug.Log("enter in emplacement");
            isOnEmplacement = true;

        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Camaro")
        {
            Debug.Log("quitte emplacement");
            isOnEmplacement = false;
        }
    }

    public void nextLevel()
    {
        
        GlobalVariables.previousLevel = "Level 08";
        GlobalVariables.nextLevel = "Level 11";
        SceneManager.LoadScene("Level Transition");

    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("Homepage");
    }




}
