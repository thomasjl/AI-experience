using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
   
    public GameObject listTargetObject;
    public GameObject listLineRenderer;
    public float speed;

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
            Debug.Log(child.gameObject.name);
            listTarget[i] = child.gameObject;
            i++;
        }
        Debug.Log("longueur tableau : " + listTarget.Length);

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
            lineRenderer.widthMultiplier = 0.2f;

            Debug.Log( "Line" + j + " " + listTarget[j].name + " - " + listTarget[j+1].name);

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
