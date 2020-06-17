using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{

    private HealthBar recoverlife;
    public float lifePoint = 150.0f;
    public GameObject lifeObject;
  



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        Destroy(lifeObject);
        PlayerController.Health += lifePoint;
        recoverlife.HealthBarCompleted();

      

       
           
    }


}
