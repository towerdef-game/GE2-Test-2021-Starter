using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : MonoBehaviour
{
    public float speed;
    public float range;
    public Transform player;
    public bool hasball;
    public BoxCollider mouth;
    public GameObject Dog;
    public Transform teeth;
    public AudioSource source;
  //  private bool seeking;
 
    public enum State
    {
        gotoplayer,
        idle,
        seek,
        comeback
    }

    public static State brok;

    public void Awake()
    {
        brok = State.idle;
    }

    public void Update()
    {
        switch (brok)
        {
          
            case State.idle:
                searchforball();
                break;

            case State.seek:
                getball();          
                break;

            case State.comeback:
                Return();
                break;

        }
     
        if (Vector3.Distance(transform.position, player.transform.position) > 11)
        {
            
            mouth.enabled = true;
        }

    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "ball" && !hasball )
        {
            other.transform.parent = Dog.transform;
            other.transform.position = teeth.transform.position;
            other.attachedRigidbody.isKinematic = true;
            hasball = true;
            brok = State.comeback;
            
        }
    }

    public void searchforball()
    {
        if (GameObject.FindGameObjectWithTag("ball"))
        {
            Debug.Log("idle");
       
            brok = State.seek;
            source.Play();
        }
      //  transform.LookAt(player);
    }




    public void getball()
    {

        GetComponent<Seek>().enabled = true;
    
    }
    public void Return()
    {
        //  GetComponent<Seek>().targetGameObject = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Seek>().enabled = false;
        GetComponent<Arrive>().enabled = true;
        GetComponent<Arrive>().hasball = true;
        Debug.Log("home");
    }
}
