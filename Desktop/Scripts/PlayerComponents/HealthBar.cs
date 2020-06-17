using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject healthbarGreen;


    private RectTransform theTransform = null;


    public float maxSpeed = 10.0f;

    void Awake()
    {
        theTransform = GetComponent<RectTransform>();    //Los "RecTransfomr" son los objetos de posicion y transformacion
    }


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.player != null)
            HealthBarCompleted();
    }

    // Update is called once per frame
    void Update()
    {

        float healthUpdate = 0.0f;

        if(PlayerController.player != null)
        {
            healthUpdate = Mathf.MoveTowards(theTransform.rect.width, PlayerController.Health, maxSpeed);

            theTransform.sizeDelta = new Vector2(
                Mathf.Clamp(healthUpdate,0, 150),
                theTransform.sizeDelta.y
                );

        }

        if (PlayerController.Health == 0.0f)
            Destroy(healthbarGreen);

    }

    public void HealthBarCompleted()
    {
        theTransform.sizeDelta = new Vector2(
              Mathf.Clamp(PlayerController.Health, 0, 150), //Se mapee el ancho de la barra de vida maxima al empezar el vieojuego
              theTransform.sizeDelta.y
              );
    }


}


/*
 * "METODO SIZEDELTA": El tamaño de este RectTransform en relación con las distancias entre los anclajes.

Si los anclajes están juntos, sizeDelta es lo mismo que size. Si los anclajes se encuentran en cada una de las cuatro 
esquinas del elemento primario, sizeDelta es cuánto más grande o más pequeño se compara el rectángulo con su elemento primario.

 "METODO MOVETOWARDS": Se utiliza para hacer la transicion de las barras de vida del valor actual hasta el otro segun el valor que le hayamos indicado
     
     
     */
