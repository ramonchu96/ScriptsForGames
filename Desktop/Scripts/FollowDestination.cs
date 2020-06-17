using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowDestination : MonoBehaviour
{
    public NavMeshAgent theAgent = null;
    public Transform []destination = null;
    int index;
    

    void Awake()
    {
        theAgent = GetComponent<NavMeshAgent>();    
    }

   

    public void Patrol()
    {
        

        theAgent.SetDestination(destination[0].position);

        index = index == destination.Length - 1 ? 0 : index + 1;
    
    
    
    }
}
