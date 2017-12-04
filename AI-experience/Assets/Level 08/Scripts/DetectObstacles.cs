using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObstacles : MonoBehaviour {

    private MeshRenderer mesh;
    private bool isEnabled;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();   
        mesh.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            mesh.enabled = true;
            isEnabled = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (isEnabled && other.tag == "Obstacle")
        {
            isEnabled = false;
            mesh.enabled = false;
        }

    }
}
