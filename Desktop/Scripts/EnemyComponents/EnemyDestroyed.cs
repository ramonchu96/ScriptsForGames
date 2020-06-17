using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyed : MonoBehaviour
{
    public GameObject enemyDeadprefab = null;
    private Transform theTransform = null;
    public Vector2 timeDelayRange = Vector2.zero;


    public float deadLifetime = 2.0f;
    public float deadSpeed = 4.0f;


    public GameObject player;
    public GameObject enemy;

    private void Awake()
    {
        theTransform = GetComponent<Transform>();
    }




    public float Health
    {
        get
        {

            return _health; //devulevo el valor de la vida
        }

        set
        {

            _health = value;  //asignamos el valor de la vida por el valor que sea

            if (_health <= 0f)    //realizamos la operacion logica
            {

                Die();
                Debug.Log("Enemigo destruido");
            }

        }

    }

    [SerializeField]
    private float _health = 10.0f;

    void Die()
    {
        Destroy(enemy);
        //al igual que el enemigo se destruye activamos instancia del enemigo muerto
        AnimationDead();

      
    }
    //--------Metodo de instanciacion del enemigo muerto--------
    void AnimationDead()
    {
        GameObject AnimationDead = Instantiate(enemyDeadprefab, theTransform.position, theTransform.rotation) as GameObject;

       

        Movement movementComponent = AnimationDead.GetComponent<Movement>();

    
        movementComponent.speed = deadSpeed;
        enemyDeadprefab.transform.position = theTransform.transform.position;

        Invoke("AnimationDead", Random.Range(timeDelayRange.x, timeDelayRange.y));


    

    }

    // Update is called once per frame
    void Update()
    {
        //Si la vida es 0 activa el metodo Die()
        if (Health <= 0)
            Die();

      




    }




    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Feet")
        {
            if (player.transform.position.y > enemy.transform.position.y)
                _health = 0f;
                 Die();


        }


    }
}
