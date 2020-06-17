using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlatform : MonoBehaviour
{
    //Objeto para activar el metodo
    public GameObject Object;
    //Objetos inactivos
    public GameObject[] ObjectInActive;
    //Objetos activos
    public GameObject[] ObjectActive;


    

  

    void OnTriggerEnter2D(Collider2D collision)
        {

     

        if (!collision.CompareTag("Player"))// si no es el jugador sal entonces esto comprueba que el resto del codigo solo se ejecute si choca con el jugador
            return;

        foreach (GameObject ObjectActive in ObjectActive)
        {

            ObjectActive.SetActive(true);   //Activamos la plataforma que se va a mover
        }

        foreach (GameObject ObjectInActive in ObjectInActive)
        {
            Destroy(ObjectInActive);        //Destruimos la plataforma inactiva

        }


        
            Destroy(Object);                //Destruimos el objeto de cogemos

        





    }

   
}
