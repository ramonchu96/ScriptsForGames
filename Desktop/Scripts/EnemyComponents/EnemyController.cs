using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;
 
    public float updateTime;

    public float timeArea = 5f;
    public float returnTimeArea = 5;
   


    void Update()
    {



        updateTime -= Time.deltaTime;

        if(updateTime <= 0)
        {
            updateTime = returnTimeArea;
        }


        //Movimiento del enemigo de un lado a otro segun el timeArea

        if (updateTime <= timeArea)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2(0.069264f, 0.082677f);


        }else if (updateTime >= timeArea)
        {
            transform.Translate(-2 * Time.deltaTime * speed,0,0);
            transform.localScale = new Vector2(-0.069264f, 0.082677f);

        }


    }

}
