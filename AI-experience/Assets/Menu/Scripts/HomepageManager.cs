using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomepageManager : MonoBehaviour {

    public void selectNewGame()
    {
        
    }

    public void selectLoadGame()
    {

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
