using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour {

    public GameObject endUIPanel;
    private GameObject player;

    void Start()
    {
        endUIPanel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");

    }
      

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            endUIPanel.SetActive(true);
            player.SetActive(false);
        }
    }

    public void nextLevel()
    {
        GlobalVariables.nextLevel = "Level 08";
        GlobalVariables.previousLevel = "Level 07";
        SceneManager.LoadScene("Level Transition");

    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("Homepage");
    }

}
