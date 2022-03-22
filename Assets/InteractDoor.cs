using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour
{
    public GameObject door;
    public bool isOpen;
    public bool movingUp;
    public bool movingDown;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet") {

            if(movingUp || movingDown)
                return;

            if(!isOpen) {
                GetComponent<Renderer>().material.color = Color.green;
                //door.transform.position += new Vector3(0,2,0);
                movingUp = true;
                StartCoroutine(resetDoor());
            } else {
                GetComponent<Renderer>().material.color = Color.red;
                //door.transform.position += new Vector3(0,-2,0);
                movingDown = true;
                StartCoroutine(resetDoor());
            }

            isOpen = !isOpen;


        }
    }

    IEnumerator resetDoor() {
        yield return new WaitForSeconds(2f);
        movingUp = false;
        movingDown = false;
    }


    void FixedUpdate() {

        if(movingUp) {
            door.transform.position += new Vector3(0,0.03f,0);
        } 
        if(movingDown) {
            door.transform.position += new Vector3(0,-0.03f,0);
        }


    }
 
 }
