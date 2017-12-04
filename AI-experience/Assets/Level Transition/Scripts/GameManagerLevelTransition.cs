using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerLevelTransition : MonoBehaviour {


    public void replayLevel()
    {
        SceneManager.LoadScene(GlobalVariables.previousLevel);
    }

    public void playNextLevel()
    {


    }



}
