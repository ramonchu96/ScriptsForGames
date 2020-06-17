using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float time = 5f;
    Animator playerAnim;

    void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }


    public float HealthPoints
    {
        get
        {
            return healthPoints;
        }
        set
        {
            healthPoints = value;
        
          
        
        
        }
    }

    void Update()
    {
        if (healthPoints <= 0)
        {
            time -= Time.deltaTime;


            playerAnim.Play("Death");
            if (time <= 0)
            {
                Destroy(gameObject);
            }

        }
    }

    [SerializeField]
    private float healthPoints = 100.0f;

}
