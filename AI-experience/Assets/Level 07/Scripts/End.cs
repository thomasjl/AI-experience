using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

    public GameObject light;

    private GameObject player;
    private float startY;
    private float startLightIntensity;

    private bool launchEnd;
    private float oldY;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startY = player.transform.position.y;
        startLightIntensity = light.GetComponent<Light>().intensity;

        launchEnd = false;
        oldY = startY;
    }

    void Update()
    {
        if (launchEnd)
        {
            if (player.transform.position.y != oldY)
            {
                light.GetComponent<Light>().intensity += 1f * (- oldY +player.transform.position.y);
                if (light.GetComponent<Light>().intensity < startLightIntensity)
                {
                    light.GetComponent<Light>().intensity = startLightIntensity;
                }

                Debug.Log(0.1f * (Mathf.Abs(startLightIntensity - player.transform.position.y)));
                oldY = player.transform.position.y;
            }

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            launchEnd = true;
        }
        
    }
}
