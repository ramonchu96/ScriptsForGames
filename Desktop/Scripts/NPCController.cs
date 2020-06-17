using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    //public float patrolTime = 15;
    public float aggroRange = 10;
    public float radioAttack = 3;


    float speed, agentSpeed;
    public Transform player;

    Animator anim;
    NavMeshAgent agent;

    //----------AREA DE COMBATE--------------

    public Vector3 direccionLeft;
    public Vector3 direccionRight;
    public float moveRotate;
    public GameObject eje;

    public float time = 50f;


    //----------------------------------------

    private Health playerHealth = null;

    public float maxDamage = 10.0f;

    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agentSpeed = agent.speed;
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        InvokeRepeating("Tick", 0, 0.5f);



    }


    public void Tick()
    {

        agent.speed = agentSpeed / 2;



        if (player != null && Vector3.Distance(transform.position, player.position) < aggroRange)
        {

            anim.SetBool("isRunning", true);
            agent.destination = player.position;
            agent.speed = 10;
        }
        else
        {
            anim.SetBool("isRunning", false);
        }



    }

    public void Attack()
    {
        time -= Time.deltaTime;



        if (player != null && Vector3.Distance(transform.position, player.position) < radioAttack)
        {
            anim.SetBool("isIdleAttack", true);

            agent.speed = 0;
        }
        else
        {
            anim.SetBool("isIdleAttack", false);
            Tick();
        }


        //---------------Conjunto de ataques de AI-----------------


        //--------------------Rotaciones-------------------

        //Rotacion_izquierda

        if ((time <= 25 && time >= 20))

            RotateLeft();


        //Rotacion_derecha

        if ((time <= 16 && time >= 13) || (time <= 9 && time >= 8))

            RotateRight();

        //------------------------------------------------------

        //Ataque_Espada

        if ((time <= 19 && time >= 17) || (time <= 7 && time >= 6) || (time <= 2 && time >= 1))

            PunchSword();

        //------------------------------------------------------


        //Defensa_Espada

        if ((time <= 12 && time >= 10) || (time <= 5))

            BlockSword();


        //------------------------------------------------------


        //Vuelve a arrancar el temporizador de ataques
        if (time < 1)
            time = 25f;


        //---------Retorna de sale del areadeataque--------------

        if (player != null && Vector3.Distance(transform.position, player.position) > radioAttack)
        {
            anim.Play("Run");
            Tick();
        }

        //------------------------------------------------------

    }






    //----------------------METODO DE ROTACION IZQUIERDA/DERECHA---------------

    public void RotateLeft()
    {

        anim.Play("WalkRight");


        transform.RotateAround(eje.transform.position, direccionLeft, moveRotate * Time.deltaTime);



    }

    public void RotateRight()
    {

        anim.Play("AimedWalkLeft");

        transform.RotateAround(eje.transform.position, direccionRight, moveRotate * Time.deltaTime);

    }


    //-------------------------------------------------------------------

    public void BlockSword()
    {
        anim.Play("Defense_HoldingSword");


    }
    void PunchSword()
    {
        anim.Play("WeakAttack_SwordA");
        if (player != null && Vector3.Distance(transform.position, player.position) < 1)
        {
            playerHealth.HealthPoints -= maxDamage * Time.deltaTime;

        }




    }

  
       




}
