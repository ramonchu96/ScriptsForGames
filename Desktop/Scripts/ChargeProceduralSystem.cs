using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeProceduralSystem : MonoBehaviour
{

   

    public GameObject cam;
    public GameObject npc;


    public bool _setanim = false;
    Animator anim;

    void Awake()
    {
  
        anim = GetComponent<Animator>();
    }




    void Update()
    {

       

        if (Input.GetKey(KeyCode.E) && _setanim == true)
        {


             
                OnSecondCamera();
                Destroy(npc);
            




        }
        else
        {
            cam.SetActive(false);
            anim.Play("CameraStop");
        }


    }



    void OnSecondCamera()
    {
        cam.SetActive(true);
        anim.Play("CameraAnimation");
       
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player")  )
        {
            _setanim = true;
        }
        else
        {
            _setanim = false;
        }
    }



}

