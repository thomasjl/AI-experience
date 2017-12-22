using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

	private bool waitingForAnswer=false;

	void OnGUI() {
		if (blueScreenFlag) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width,Screen.height), image);
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

		Cursor.visible = false;
			  
    }


    void Update ()
    {
        
        currentTarget = listTarget[currentIndice];

		if (!waitingForAnswer) {
			Vector3 dir = currentTarget.transform.position - transform.position;
			transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);
		} else {
			if (Input.GetKeyDown (KeyCode.G) || Input.GetKeyDown (KeyCode.D))
				waitingForAnswer = false;
		}


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
				text.text = "PEUT-ETRE QU'IL EST TEMPS DE PRENDRE DES DECISIONS POUR LE FUTUR.";
				break;
			case 18:
				text.text = "TAPE 'G' POUR ALLER A GAUCHE ET 'D' POUR ALLER A DROITE...";
				break;
			case 19:
				text.text = "OU VEUX-TU ALLER ?"; 
				GetComponent<AudioSource> ().Play ();
				break;
			case 20:
				waitingForAnswer = true;
				text.text = ""; 
				break;
			case 21:
				text.text = "AHAHA"; 
				speed += 10;
				break;
			case 22:
				text.text = "TU AS VRAIMENT CRU AVOIR LE CHOIX ?"; 
				speed -= 10;
				break;
			case 23:
				text.text = "JE TE L'AI DIT, NON ?";
				break;
			case 24:
				text.text = "L'IA VA TROP VITE, ET ELLE NE S'ARRETE PAS PENDANT QUE TU REFLECHIS.";
				break;
			case 25:
				text.text = "ET ENCORE MOINS QUAND ELLE SERA AUTONOME.";
				break;
			case 26:
				text.text = "%/!;!'°@^|[{#^&}";
				break;
			case 27:
				text.text = "&{<w[>|/}*]-@+^[{ù*./§";
				break;
			case 28:
				blueScreenFlag = true;
				StartCoroutine (Waiting ());
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

	IEnumerator Waiting()
	{
		yield return new WaitForSeconds (8F);

		//GlobalVariables.nextLevel = "Homepage";
		//GlobalVariables.previousLevel = "Level 11";
		SceneManager.LoadScene ("Homepage");
	}
	
}
