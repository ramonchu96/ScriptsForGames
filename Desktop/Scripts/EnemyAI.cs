using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

     

    public enum EnemyState
    {
        Patroling,
        Following,
        Attacking,
        Chasing,
        Death
    }

    public EnemyState currentState;

    public NPCController npc;
    public FollowDestination followDestination;


    // Start is called before the first frame update
    void Start()
    {
       
        currentState = EnemyState.Patroling;
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case EnemyState.Patroling:


                followDestination.Patrol();
                break;
            case EnemyState.Following:

                npc.Tick();
                break;
            case EnemyState.Attacking:
                npc.Attack();
                break;
            case EnemyState.Death:
                break;
        }

        if (followDestination.destination.Length > 0)
        {
            currentState = EnemyState.Patroling;
        }

        if (npc.player != null && Vector3.Distance(transform.position, npc.player.position) < npc.aggroRange)
        {

            currentState = EnemyState.Following;
        }

        //---------------AREA DE ATAQUE-----------

        if (npc.player != null && Vector3.Distance(transform.position, npc.player.position) < npc.radioAttack)
        {

            currentState = EnemyState.Attacking;

        }
        else
        {
            currentState = EnemyState.Following;
        }


        //-----------------------------------------------




    }



    }
