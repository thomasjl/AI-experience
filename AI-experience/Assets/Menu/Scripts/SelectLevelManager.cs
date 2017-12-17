using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelManager : MonoBehaviour {
    

    public void selectLevel1()
    {
        GlobalVariables.nextLevel = "Level 01";
        launchLevelTransition();
    }

    public void selectLevel2()
    {
        GlobalVariables.nextLevel = "Level 02";
        launchLevelTransition();
    }

    public void selectLevel3()
    {
        GlobalVariables.nextLevel = "Level 05";
        launchLevelTransition();
    }

    public void selectLevel4()
    {
        GlobalVariables.nextLevel = "Level 07";
        launchLevelTransition();
    }

    public void selectLevel5()
    {
        GlobalVariables.nextLevel = "Level 08";
        launchLevelTransition();
    }

    public void selectLevel6()
    {
        GlobalVariables.nextLevel = "Level 11";
        launchLevelTransition();
    }

    void launchLevelTransition()
    {
        GlobalVariables.previousLevel = "NoReturn";
        SceneManager.LoadScene("Level Transition");
    }
}
