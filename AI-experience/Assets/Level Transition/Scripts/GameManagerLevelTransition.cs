using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerLevelTransition : MonoBehaviour {

    public GameObject lvl1Frame;
    public GameObject lvl2Frame;
    public GameObject lvl5Frame;
    public GameObject lvl7Frame;
    public GameObject lvl8Frame;
    public GameObject lvl11Frame;

    public Text previousLevelText;
    public Text nextLevelText;



    void Start()
    {
        //afficher les bons cadres,images
        if (GlobalVariables.nextLevel == "Level 01")
        {
            lvl1Frame.SetActive(true);
            nextLevelText.text = " Appuyer sur 'E' pour jouer le niveau 1 : Machine Enigma";
        }
        else if (GlobalVariables.nextLevel == "Level 02")
        {
            lvl2Frame.SetActive(true);
            nextLevelText.text = " Appuyer sur 'E' pour jouer le niveau 2 : Test de Turing";
        }
        else if (GlobalVariables.nextLevel == "Level 05")            
        {
            lvl5Frame.SetActive(true);
            nextLevelText.text = " Appuyer sur 'E' pour jouer le niveau 3 : Echecs contre Kasparov";
        }
        else if (GlobalVariables.nextLevel == "Level 07")
        {
            lvl7Frame.SetActive(true);
            nextLevelText.text = " Appuyer sur 'E' pour jouer le niveau 4 : Machin Learning";
        }
        else if (GlobalVariables.nextLevel == "Level 08")
        {
            lvl8Frame.SetActive(true);
            nextLevelText.text = " Appuyer sur 'E' pour jouer le niveau 5 : Voiture autonome";
        }
        else if (GlobalVariables.nextLevel == "Level 11")
        {
            lvl11Frame.SetActive(true);
            nextLevelText.text = " Appuyer sur 'E' pour jouer le niveau 6 : Futur de l'IA";
        }


    }


    public void replayLevel()
    {
        if (GlobalVariables.previousLevel != null || GlobalVariables.previousLevel != "NoReturn")
        {
            SceneManager.LoadScene(GlobalVariables.previousLevel);
        }


    }

    public void playNextLevel()
    {
        if (GlobalVariables.nextLevel != null)
        {
            SceneManager.LoadScene(GlobalVariables.nextLevel);
        }
        else
        {
            Debug.Log("no level available !");
        }

    }



}
