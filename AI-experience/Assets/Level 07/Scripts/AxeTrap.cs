using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTrap : MonoBehaviour {

    private Animation anim;

	// Use this for initialization
	void Start () {		

        anim = GetComponent<Animation>();
        StartCoroutine("StartAnimation");
	}
	
    IEnumerator StartAnimation()
    {
        float startTime = Random.Range(0, 1f);
        yield return new WaitForSeconds(startTime);
        anim.Play();
    }
}
