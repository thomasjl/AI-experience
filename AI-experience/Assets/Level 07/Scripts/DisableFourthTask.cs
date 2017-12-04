using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFourthTask : MonoBehaviour {

    public GameObject disableFourthTaskUi;
    public GameObject lightings1;
    public GameObject lightings2;
    public GameObject lightings3;

    private bool uiPrinted;

    public int attemptNumber;

    void Start()
    {
        disableFourthTaskUi.SetActive(false);
        attemptNumber = 0;
        uiPrinted = false;
    }

    void Update()
    {
        if (uiPrinted)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown("1"))
            {
                lightings1.SetActive(false);
                lightings2.SetActive(false);
                lightings3.SetActive(false);
                disableFourthTaskUi.SetActive(false);
                uiPrinted = false;

                GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = 3;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown("2"))
            {
                disableFourthTaskUi.SetActive(false);
                uiPrinted = false;
            }
           
        }


        if (attemptNumber > 3)
        {
            disableFourthTaskUi.SetActive(true);
            uiPrinted = true;
            attemptNumber = 0;
        }
            

    }

    /*
    public void yesButton()
    {
        //not used
        {
            lightings1.SetActive(false);
            lightings2.SetActive(false);
            lightings3.SetActive(false);
        }
    }

    public void noButton()
    {
        //redemande dans 3 tentatives
        attemptNumber = 0;
    }
    */

}
