using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float speed;
    public GameObject elevator;


    public bool closing;
    public bool openning;

    private float t1;
    private float t2;
   

    void Start()
    {

        //closed = transform.position;
        //opened = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
        closing = false;
        openning = false;


        t1 = 0;
        t2 = 0;
      

    }

    void Update()
    {
        if (openning)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.left, speed * Time.deltaTime);
            t1 += Time.deltaTime;
            //float distance = Vector3.Distance(transform.position, opened);

            // si la porte est entrouverte, elle n'est pas ferme
            elevator.GetComponent<Elevator>().doorClosed = false;
            if (t1 >= 1f)
            {
                t1 = 0;
                openning = false;    


            }

        }
        else if (closing)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position - Vector3.left, speed * Time.deltaTime);

            t2 += Time.deltaTime;
            //float distance = Vector3.Distance(transform.position, closed);
            if (t2 >= 1f)
            {
                t2 = 0;
                closing = false;
                elevator.GetComponent<Elevator>().doorClosed = true;

            }          

        }

    }

   
        

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player" && (!elevator.GetComponent<Elevator>().arrived))
        {
            StartCoroutine("waitAnimationOpenDoor");
        }

    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player" && (!elevator.GetComponent<Elevator>().arrived))
        {
            StartCoroutine("waitAnimationCloseDoor");
        }

    }

    IEnumerator waitAnimationCloseDoor()
    {
        yield return new WaitForSeconds(2);
        t2 = 0;
        openning = false;
        closing = true;
    }

    IEnumerator waitAnimationOpenDoor()
    {
        yield return new WaitForSeconds(1);
        t1 = 0;
        openning = true;
        elevator.GetComponent<Elevator>().inside = false;


    }
}
