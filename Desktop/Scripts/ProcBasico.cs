using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcBasico : MonoBehaviour
{
    public GameObject[] objetosPosibles;

    public ChargeProceduralSystem cps;



    // Start is called before the first frame update



    void Update()
    {
        

        if (Input.GetKey(KeyCode.E) && cps._setanim == true)
        {
        

          
            ProceduralSystem();

            Destroy(gameObject);
            

         
        }

        
       
    }

    public void ProceduralSystem()
    {

      

        Instantiate(
           objetosPosibles[UnityEngine.Random.Range(0, objetosPosibles.Length)],
           transform.position,
           Quaternion.Euler(Vector3.up * (UnityEngine.Random.Range(0, 4) * 90))

           );


    }


}
