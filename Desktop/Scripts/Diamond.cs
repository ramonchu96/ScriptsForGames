using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public static int diamondCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Moneda Creada");
        Diamond.diamondCount++;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    void OnTriggerEnter (Collider playercollider)
    {
        Debug.Log("He tocado el diamante");
        if (playercollider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Diamond.diamondCount--;
        if (Diamond.diamondCount <= 0)
        {
            GameObject timer = GameObject.Find("GameTimer");
            Destroy(timer);

            GameObject[] fireworks = GameObject.FindGameObjectsWithTag("FireWork");

            foreach(GameObject firework in fireworks)
            {
                Debug.Log("Activando fuegos");

                firework.GetComponent<ParticleSystem>().Play();
            }


        }

    }

}
