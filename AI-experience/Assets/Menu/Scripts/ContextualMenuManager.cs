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
	public GameObject homeMadeCamera;

	private bool cursorInitiallyVisible;


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
                Time.timeScale = 0;
            }
            else
            {
                closeMenuContextual();
                Time.timeScale = 1;
            }

        }
    }

    public void resumeButton()
    {
		Time.timeScale = 1;
        Debug.Log("resume button");
        closeMenuContextual();
    }

    public void reloadButton()
    {
		Time.timeScale = 1;
        SceneManager.LoadScene("Level Transition");
    }

    public void returnToMenu()
    {
		Time.timeScale = 1;
        SceneManager.LoadScene("Homepage");
    }

    private void openMenuContextual()
    {
        //cam.SetActive(false); 

        //menuCam.SetActive(true);

		cursorInitiallyVisible = Cursor.visible;

        contextualMenu.SetActive(true);
        contextualMenuOpen = true;
		Cursor.visible = true;

        if (fpsController != null)
        {
           // fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;

            fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.lockCursor = false;
            fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.XSensitivity = 0;
            fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.YSensitivity = 0;

        }

		if (homeMadeCamera != null) 
		{
			homeMadeCamera.GetComponent<Main_Camera> ().speedH = 0.0f;
			homeMadeCamera.GetComponent<Main_Camera> ().speedV = 0.0f;
		}
       
                         
               
    }

    private void closeMenuContextual()
    {
        //cam.SetActive(true); 

        //menuCam.SetActive(false);



        Debug.Log("close menu");
        contextualMenuOpen = false;

        contextualMenu.SetActive(false);

		if (!cursorInitiallyVisible)
			Cursor.visible = false;

        if (fpsController != null)
        {
            fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.lockCursor = true;
            fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.XSensitivity = 2f;
            fpsController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.YSensitivity = 2f;

        }

		if (homeMadeCamera != null) 
		{
			homeMadeCamera.GetComponent<Main_Camera> ().speedH = 2.0f;
			homeMadeCamera.GetComponent<Main_Camera> ().speedV = 2.0f;
		}
           
      
       
    }

}
