using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove_old : MonoBehaviour {
   
    public GameObject listTargetObject;
    public GameObject listLineRenderer;
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

        for (int j = 0; j < (listTarget.Length - 1); j++)
        {
            if (listTarget[j+1] == null)
            {
                break;
            }
            
            //creer game object fils de listLineRenderer
            //ajouter component
            GameObject lineGameObject = new GameObject("Line" +j);
            lineGameObject.transform.parent = listLineRenderer.transform;

            LineRenderer lineRenderer = lineGameObject.AddComponent<LineRenderer>();
			lineRenderer.material = new Material (Shader.Find("Particles/Additive"));
			lineRenderer.SetColors (Color.blue, Color.blue);
            lineRenderer.widthMultiplier = 0.2f;

            lineRenderer.SetPositions(new Vector3[2] {listTarget[j].transform.position, listTarget[j + 1].transform.position});
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
			case 9:
				text.text = "QUEL EST LE FUTUR DE L'IA ?";
				break;
			case 10:
				text.text = "TELLEMENT DE POSSIBILITES...";
				break;
			case 11:
				text.text = "IL VA FALLOIR FAIRE UN CHOIX.";
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
