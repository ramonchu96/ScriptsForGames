using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float damage = 180.0f;

    //-----Tiempo de la bala------------
    public float lifetime = 2.0f;


    // Invocamos el metodo "Die" con la variable con el lifetime de tiempo de bala
    void Start()
    {
        Invoke("Die",lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        PlayerController.Health -= damage;
        Destroy(gameObject);
    }


    void Die()
    {
        Destroy(gameObject);
    }

}
