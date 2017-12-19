using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ContextualMenuManager : MonoBehaviour {

    public GameObject contextualMenu;
    private bool contextualMenuOpen;

    //public GameObject menuCam;

    //private GameObject cam;

    public GameObject fpsController;


    void Start()
    {
        contextualMenu.SetActive(false);
        contextualMenuOpen = false;
               
        //menuCam.SetActive(false);

        //cam = GameObject.FindGameObjectWithTag("MainCamera");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!contextualMenuOpen)
            {                

                openMenuContextual();
                // jeu en pause
                //Time.timeScale = 0;
            }
            else
            {
                closeMenuContextual();
                //Time.timeScale = 1;
            }

        }
    }

    public void resumeButton()
    {
        Debug.Log("resume button");
        closeMenuContextual();
    }

    public void reloadButton()
    {
        SceneManager.LoadScene("Level Transition");
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("Homepage");
    }

    private void openMenuContextual()
    {
        //cam.SetActive(false); 

        //menuCam.SetActive(true);

        contextualMenu.SetActive(true);
        contextualMenuOpen = true;

        if (fpsController != null)
        {
           // fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;

            fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.lockCursor = false;
            fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.XSensitivity = 0;
            fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.YSensitivity = 0;
            Cursor.visible = true;

        }
       
                         
               
    }

    private void closeMenuContextual()
    {
        //cam.SetActive(true); 

        //menuCam.SetActive(false);



        Debug.Log("close menu");
        contextualMenuOpen = false;

        contextualMenu.SetActive(false);

        if (fpsController != null)
        {
            fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.lockCursor = true;
            fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.XSensitivity = 2f;
            fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.YSensitivity = 2f;
            Cursor.visible = false;


        }


           
      
       
    }

}
