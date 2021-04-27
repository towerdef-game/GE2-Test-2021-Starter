using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tail : MonoBehaviour

{
    public float swingrate;
    public Transform dogstail;
    public float tailRadius;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        dogstail.localRotation = Quaternion.RotateTowards(dogstail.localRotation, Quaternion.Euler(0, tailRadius, 0), swingrate);
        if (dogstail.localRotation == Quaternion.Euler(0, tailRadius, 0)) tailRadius = -tailRadius;
    }
}

