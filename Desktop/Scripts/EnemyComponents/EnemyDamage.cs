using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float damage;
    public float damageTime;

    public float counter;
    public bool hasHit;

    public EnemyDestroyed enemyDestroyed;


    // Update is called once per frame
    void Update()
    {
        if (hasHit)
        {
            //--------Tiempo de inmunidad del jugador con el enemigo---
            counter += Time.deltaTime;
            if (counter > damageTime)
            {
                counter = 0;
               
                hasHit = false;
              

            }

        }

       else counter = 0;

    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        //------Daño del jugador tras colisionar con el enemigo

        if(collision.tag == "Player")
        {
            if(!hasHit)

            PlayerController.Health -= damage;
            hasHit = true;

        }


        //-----Eliminacion del enemigo al ser pisado

            if (collision.tag == "Feet")
            {
                if (enemyDestroyed.player.transform.position.y > enemyDestroyed.enemy.transform.position.y)
                hasHit = true;

                }

        }
    }
