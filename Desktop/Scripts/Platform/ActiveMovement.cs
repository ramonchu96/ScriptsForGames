using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMovement : MonoBehaviour
{

    //---------------Movimiento PING PONG-----------

    private Transform theTransform = null;
    private Vector3 originPosition = Vector3.zero;

    public Vector3 moveDirection = Vector3.zero;
    public float distance = 3.0f;

    //------------Metodo public para la realizacion del movimiento en la plataforma estatica
    public ActivePlatform platform;

    void Awake()
    {
        theTransform = GetComponent<Transform>();
        originPosition = theTransform.position;
    }

   
  

       public void ActiveMove() {
       
        theTransform.position = originPosition + moveDirection * Mathf.PingPong(Time.time, distance); //Crea una transicion lineal --> Mathf.PingPong , (2 * Time.time --> ira mas rapido)

        }



    void Update()
    {
        //-----Si el objeto de la plataforma estatica es igual a null activamos el metodo "ActiveMove()"
        if(platform.Object == null)
        {
            

                ActiveMove();
            
        }



    }






}
