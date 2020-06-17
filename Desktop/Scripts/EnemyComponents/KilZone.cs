using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilZone : MonoBehaviour
{
    public float damage = 100.0f;

    void OnTriggerStay2D(Collider2D collision)
    {

        if (!collision.CompareTag("Player"))
            return;

        if(PlayerController.player != null)
        {
            PlayerController.Health -= damage * Time.deltaTime;
        }


    }


}
