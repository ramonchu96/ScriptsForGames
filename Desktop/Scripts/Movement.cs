using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform theTransform;
    public float speed = 10.0f;

     void Awake()
    {
        theTransform = GetComponent<Transform>();    
    }

  

    // Update is called once per frame
    void Update()
    {
        theTransform.position += theTransform.forward * speed * Time.deltaTime; 
    }
}
