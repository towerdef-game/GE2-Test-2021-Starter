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
    public AudioSource source;
  //  private bool seeking;
 
    public enum State
    {
        gotoplayer,
        idle,
        seek,
        comeback
    }

    private State _state;

    private void Awake()
    {
        _state = State.idle;
    }

    private void Update()
    {
        switch (_state)
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
            _state = State.comeback;
            
        }
    }

    public void searchforball()
    {
        if (GameObject.FindGameObjectWithTag("ball"))
        {
            Debug.Log("idle");
       
            _state = State.seek;
            source.Play();
        }



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
