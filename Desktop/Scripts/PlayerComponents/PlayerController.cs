using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
     public enum FACE_DIRECTION  //Enumerado  (para añadir pequeños valores de forma rapida)
      {
          LEFT = -1,
          RIGHT = 1
      };

      public FACE_DIRECTION direction = FACE_DIRECTION.RIGHT; //declaramos ese enumerado

    public static PlayerController player = null; //una sola instacia para el jugador

    public bool canJump = true;
    public bool canRun = true;
    public bool isOnTheGround = false;


    public float jumpPower = 400;
    public float jumpTimeout = 1.0f;
    public float maxSpeed = 40.0f;

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    

    public string jumpButton = "Jump";


    private Rigidbody2D theRigidbody = null;
    private Transform theTransform = null;
    public BoxCollider2D feetCollider = null;
   // public CircleCollider2D headCollider = null;

    public LayerMask groundLayer;


    Animator PlayerAnim;
    public Joystick JoyStickMove;

  


    public static float Health
    {
        get { 
           
            return _health; //devulevo el valor de la vida
        }

        set {

        _health = value;  //asignamos el valor de la vida por el valor que sea

            if(_health <= 0)    //realizamos la operacion logica
            {
               
                Die();
                GameController.GameOver();
            
            }

        }
    
    }

    [SerializeField]
    private static float _health = 150.0f;

    void Awake()
    {
        theRigidbody = GetComponent<Rigidbody2D>();
        theTransform = GetComponent<Transform>();
        PlayerAnim = GetComponent<Animator>();


        

        player = this;
        
    }

    void FixedUpdate()
    {
        if (!canRun || Health <= 0)
            return;

        isOnTheGround = GetGrounded(); //esta en el suelo activa el metodo Grounded()

        //-------------------------MOVIMIENTO HORIZONTAL--------------------------------------------------

          
        
            float move = CrossPlatformInputManager.GetAxis("Horizontal");       //Utilizamos el paquete "CrossPlatformManager" para el control horizontal que creamos
            move += JoyStickMove.Horizontal;

         theRigidbody.AddForce(Vector2.right * move * maxSpeed);           //Añadimos una fuerza de movimiento a ese control horizontal

        theRigidbody.velocity = new Vector2(move * maxSpeed, theRigidbody.velocity.y);


        PlayerAnim.SetFloat("WhatchMove", Mathf.Abs(move)); //Animacion del movimiento

        Debug.Log("Esta moviendo");


        //-------------------------------AGACHARSE------------------------------------------------------

        float bend = CrossPlatformInputManager.GetAxis("Vertical");
        bend += JoyStickMove.Vertical;
        if(bend < 0) { 
        theRigidbody.AddForce(Vector2.up * bend);           //Añadimos una fuerza de movimiento a ese control vertical
        Debug.Log("Esta agachando");
        PlayerAnim.SetFloat("BendMove", Mathf.Abs(bend)); //Animacion del movimiento
        }


        //---------------------------Cambiamos direccion del personaje-------------------------------------

        if (move < 0 && direction != FACE_DIRECTION.LEFT || (move > 0 && direction != FACE_DIRECTION.RIGHT))
           ChangeDirection();

       


        //----------------------------Saltamos------------------------------------------------------------


        if (CrossPlatformInputManager.GetButton(jumpButton))                //Si pulsamos el boton de saltar activara nuestro metodo Jump()
        {
            Debug.Log("Esta saltando");
            Jump();
        }

     
       
       

        theRigidbody.velocity = new Vector2(

            Mathf.Clamp(theRigidbody.velocity.x, -maxSpeed, maxSpeed),  //corregimos la velocidad con la funcion Mathf.Clamp
            Mathf.Clamp(theRigidbody.velocity.y, -Mathf.Infinity, jumpPower)
            );







    }





    public void Jump()
    {
     
        if (!isOnTheGround || !canJump)
            return;
       
        theRigidbody.AddForce(Vector2.up * jumpPower); //Esta saltando
        canJump = false;                //no puede saltar
        Invoke("EnableJump", jumpTimeout);      

    }

    




    public void EnableJump()
    {
        canJump = true;
    }

    private bool GetGrounded()
    {
        Vector2 boxCenter = new Vector2(theTransform.position.x, theTransform.position.y) + feetCollider.offset;  //offset (tamaño del collider)
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(boxCenter,feetCollider.size,groundLayer); //.OverLapBox(todo lo que colisione con la caja collider)

        if(hitColliders.Length > 0) //para saber si estamos colisionando
        {
            return true; //Estoy colisionando

        }
        else
        {
            return false;   //No estamos colisionando
        }

    }

     private void ChangeDirection()
      {
          direction = (FACE_DIRECTION)((int)direction * -1.0f);
          Vector3 localScale = theTransform.localScale;   //declaramos el vector con la variable localscale
          localScale.x *= -1.0f;          //Esa variable la multiplicamos * -1 para que nos inviaerta a un lado
          theTransform.localScale = localScale;

      }




    void OnDestroy()
    {
        player = null;
    }

    static void Die()
    {
        Destroy(PlayerController.player.gameObject);  
    }


    public static void Reset()
    {
        Health = 200.0f;
    }







    //----------------------------------------------TRIGGERS && COLLIDERS-------------------------------


    public void OnCollisionEnter2D(Collision2D other)
    {


        if (other.gameObject.tag == "Platform")
        {

            this.transform.parent = other.transform;

        }

    }

    public void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.tag == "Platform")
        {

            this.transform.parent = null;

        }

    }

}

