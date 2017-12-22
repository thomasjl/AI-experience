using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomepageManager : MonoBehaviour {

    public GameObject loadLevelButton;

    void Start()
    {
        if (PlayerPrefs.GetString("progressionPlayer") == null)
        {
            loadLevelButton.GetComponent<Button>().interactable = false;
        }
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (!Cursor.visible)
        {
            Cursor.visible = true;
        }
    }


    public void selectNewGame()
    {
        GlobalVariables.nextLevel = "Level 01";
        GlobalVariables.previousLevel = "NoReturn";
        PlayerPrefs.SetString("progressionPlayer", "Level 01");
        SceneManager.LoadScene("Level Transition");
    }

    public void selectLoadGame()
    {
        GlobalVariables.nextLevel = PlayerPrefs.GetString("progressionPlayer");
        Debug.Log("progression string : " + PlayerPrefs.GetString("progressionPlayer"));
        GlobalVariables.previousLevel = "NoReturn";
        SceneManager.LoadScene("Level Transition");
    }

    public void selectChooseLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void selectQuit()
    {
        Application.Quit();
    }
        
}
