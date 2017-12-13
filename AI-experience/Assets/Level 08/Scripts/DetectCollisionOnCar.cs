using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionOnCar : MonoBehaviour {

    public GameObject hitSomething;
    public GameObject gameManager;

    void OnCollisionEnter(Collision collision)
    {
        gameManager.GetComponent<Lvl8GameManager>().damageTaken++;
        Debug.Log("detect collision");

        if (collision.gameObject.GetComponent<ReturnToStarPosition>() != null)
        {
            collision.gameObject.GetComponent<ReturnToStarPosition>().enabled = true;
        }


        foreach (ContactPoint contact in collision.contacts)
        {          

            GameObject hitPoint = Instantiate(hitSomething, contact.point, Quaternion.identity);
            //Debug.DrawRay(contact.point, contact.normal, Color.white);
            StartCoroutine("destroyHitPoint", hitPoint);
            hitPoint.transform.parent = transform;
        }
            
    }


    IEnumerator destroyHitPoint(GameObject hitObject)
    {
        yield return new WaitForSeconds(2);


        Destroy(hitObject);

    }
}
