using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : MonoBehaviour
{
    public float speed;
    public float range;
    public bool hasball;
    public GameObject Dog;
    public AudioSource source;
    public enum State
    {
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
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "ball" && !hasball)
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
            //   GameObject _ball = GameObject.FindGameObjectWithTag("ball");
            //  GetComponent<Seek>().targetGameObject = _ball;
            _state = State.seek;
        }

    }
    public void getball()
    {
        GameObject _ball = GameObject.FindGameObjectWithTag("ball");
        GetComponent<Seek>().targetGameObject = _ball;
        source.Play();
      //  transform.position = Vector3.MoveTowards(transform.position, _ball.transform.rotation, speed);
        _state = State.comeback;
    }
    public void Return()
    {
        GetComponent<Seek>().targetGameObject = GameObject.FindGameObjectWithTag("Player");

    }
}
