using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Arrive : SteeringBehaviour
{
    public Vector3 targetPosition = Vector3.zero;
    public float slowingDistance = 10.0f;

    public GameObject targetGameObject = null;
    // public BoxCollider mouth;
    public bool hasball;
    public Transform player;
    public Transform ruff; 
    public Transform  ball;
    public character_script character;
    public dog blah;

    public override Vector3 Calculate()
    {
        return boid.ArriveForce(targetPosition, slowingDistance);
    }

    public void Update()
    {
        if (targetGameObject != null)
        {
            // targetPosition = targetGameObject.transform.position;
            targetPosition = new Vector3(targetGameObject.transform.position.x, 0f, targetGameObject.transform.position.z);
        }
        if (Vector3.Distance(transform.position, targetGameObject.transform.position) < 10 && hasball)
        {
            ball = ruff.GetComponent<Seek>().targetGameObject.transform;
            ball.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(ball.gameObject);
         //   ball.SetParent(null);
            hasball = false;
          //  Destroy(ball);
            character.canthrow = true;
            ruff.GetComponent<Seek>().enabled = false;
            ruff.GetComponent<Arrive>().enabled = false;
            //  dog.GetComponent<Boid>().enabled = false;
          //  dog.GetComponent<dog>().brok = dog.State.idle;
            ruff.GetComponent<dog>().hasball = false;
            // transform.LookAt(player);
            dog.brok = dog.State.idle;
        }

        
       
    }
}