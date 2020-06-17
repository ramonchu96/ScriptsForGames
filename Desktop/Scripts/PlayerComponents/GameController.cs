using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static int score = 0;
    public string scorePrefix = "Score: ";

    public Text scoreText = null;  //Objeto canva texto
    public Text gameOverText = null;    //Objeto canva texto
    public GameObject restartbutton;
    public GameObject exitbutton;


    public static GameController gameController = null; //Una variable que se controle asi misma


    void Awake()
    {
        gameController = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        gameController.gameOverText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = scorePrefix + score.ToString();

        }
    }

    public static void GameOver()
    {
        if (gameController.gameOverText != null) //Si el game controller es diferente de null
        {
            gameController.gameOverText.gameObject.SetActive(true); //muestra el objeto por pantalla

            gameController.restartbutton.gameObject.SetActive(true);
            gameController.exitbutton.gameObject.SetActive(true);


        }
    
        
    
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        PlayerController.Health = 150.0f;
    
    }

}

