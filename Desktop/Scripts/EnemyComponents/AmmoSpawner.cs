using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject ammoPrefab = null;

    private Transform theTransform = null;

    //----Rango de vectores-----
    public Vector2 timeDelayRange = Vector2.zero;

//-----------------------Sistemas de disparos-----------------------------

    
    public float ammoSpeed = 4.0f;
    

    //--------------------------------------

    private void Awake()
    {
        theTransform = GetComponent<Transform>();
    }


    // Start is called before the first frame update
    void Start()
    {
        FireAmmo();
    }

    //--------------metodo de Instanciacion de la bala-----
    public void FireAmmo()
    {
        //Objeto instanciado como GameObject
        GameObject ammo = Instantiate(ammoPrefab,theTransform.position,theTransform.rotation) as GameObject;

        Ammo ammoComponent = ammo.GetComponent<Ammo>();

        //Cogemos el objeto Movement dentro del objeto ammo
        Movement movementComponent = ammo.GetComponent<Movement>();

        movementComponent.speed = ammoSpeed;

        //Invocacion del metodo  que instancia nuesto prefab 
        //&& instaciamos el rango con la varianle indicada

        Invoke("FireAmmo", Random.Range(timeDelayRange.x, timeDelayRange.y));



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
