using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesRendering : MonoBehaviour {

	public GameObject listFakeTargetObject;
	public GameObject listChoiceTargetObject;
	public GameObject listLineRenderer;

	private GameObject[] listTarget;

	// Use this for initialization
	void Start () {

		foreach (Transform child in listFakeTargetObject.transform)
		{
			int i = 0;
			listTarget = new GameObject[100];
			foreach (Transform grandchild in child.transform) {
				Debug.Log (grandchild.gameObject.name);
				listTarget [i] = grandchild.gameObject;
				i++;
			}
			LineRendering (listTarget);
		}

		foreach (Transform child in listChoiceTargetObject.transform)
		{
			int i = 0;
			listTarget = new GameObject[100];
			foreach (Transform grandchild in child.transform) {
				Debug.Log (grandchild.gameObject.name);
				listTarget [i] = grandchild.gameObject;
				i++;
			}
			LineRendering (listTarget);
		}
		
	}

	void LineRendering(GameObject[] listTarget){
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
			lineRenderer.SetColors (Color.white, Color.white);
			lineRenderer.widthMultiplier = 0.2f;

			//Debug.Log( "Line" + j + " " + listTarget[j].name + " - " + listTarget[j+1].name);

			lineRenderer.SetPositions(new Vector3[2] {listTarget[j].transform.position, listTarget[j + 1].transform.position});
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
