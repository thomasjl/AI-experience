using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
   
    public GameObject listTargetObject;
    public float speed;
	public Text text;

	public Texture image;

    private GameObject[] listTarget;

    private GameObject currentTarget;
    private int currentIndice;

    private bool isTarget;

	private bool blueScreenFlag=false;

	void OnGUI() {
		if (blueScreenFlag) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width,Screen.height), image);
			Debug.Log ("Acqui");
		}
	}

    void Start()
    {
        isTarget = true;

        listTarget = new GameObject[100];

        currentIndice = 0;
        int i = 0;
        foreach (Transform child in listTargetObject.transform)
        {
            listTarget[i] = child.gameObject;
            i++;
        }
			  
    }


    void Update ()
    {
        
        currentTarget = listTarget[currentIndice];

        Vector3 dir = currentTarget.transform.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //transform.position = Vector3.Lerp(transform.position, currentTarget.transform.position, speed * Time.deltaTime);

        if (Vector3.Distance (transform.position, currentTarget.transform.position) <= 0.4f && isTarget) {
            GetNextWayPoint ();
			if (currentIndice < 10 || currentIndice >= 20)
				speed += 5;
			else
				speed -= 5;
			switch (currentIndice) {
			case 1:
				text.text = "QUEL EST LE FUTUR DE L'IA ?";
				break;
			case 2:
			case 3:
				text.text = "TELLEMENT DE POSSIBILITES...";
				break;
			case 4:
			case 5:
				text.text = "EST-CE QU'ON PEUT SEULEMENT INFLUER SUR SON FUTUR ?";
				break;
			case 6:
			case 7 :
				text.text = "EST-CE QUE CA NE VA PAS TROP VITE ?";
				break;
			case 8 :
			case 9 :
				text.text = "ON NE CHOISIT PAS LA DIRECTION DE L'AVENIR DE L'IA.";
				break;
			case 11:
			case 12:
				text.text = "NE DEVRIONS-NOUS PAS PRENDRE LE TEMPS D'Y REFLECHIR ?";
				break;
			case 17:
				text.text = "PEUT-ETRE QUE CERTAINES DECISIONS SERONT UN TOURNANT POUR LE FUTUR.";
				break;
			case 18:
				text.text = "ET SI CES DECISIONS ETAIENT MAINTENANT...";
				break;
			case 19:
				text.text = "OU VEUX-TU ALLER ?"; 
				GetComponent<AudioSource>().Play ();
				break;
			case 20:
				text.text = "AHAHAH"; 
				break;
			case 21:
				text.text = "TU AS VRAIMENT CRU AVOIR LE CHOIX ?"; 
				break;
			case 22:
				text.text = "JE TE L'AI DIT, NON ?";
				break;
			case 23:
				text.text = "L'IA VA TROP VITE, ET ELLE NE S'ARRETE PAS PENDANT QUE TU REFLECHIS.";
				break;
			case 24:
				text.text = "ET ENCORE MOINS QUAND ELLE SERA AUTONOME.";
				break;
			case 25:
				text.text = "BIIIIPPPP";
				break;
			case 26:
			case 27:
				text.text = "COMPUTER UNDER CONTROL";
				break;
			case 28:
				blueScreenFlag = true;
				break;
			default:
				text.text = ""; 
				break;
			}
        }

    }

    void GetNextWayPoint()
    {     
        if (listTarget[currentIndice + 1] != null)
        {
            currentIndice++;
        }
        else
        {
            isTarget = false;
        }

    }
	
}
