using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
   
    public GameObject listTargetObject;
    public float speed;
	public Text text;

    private GameObject[] listTarget;

    private GameObject currentTarget;
    private int currentIndice;

    private bool isTarget;

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
			switch (currentIndice) {
			case 2:
				text.text = "QUEL EST LE FUTUR DE L'IA ?";
				break;
			case 3:
				text.text = "TELLEMENT DE POSSIBILITES...";
				break;
			case 4:
				text.text = "EST-CE QU'ON PEUT SEULEMENT INFLUER SUR SON FUTUR ?";
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
