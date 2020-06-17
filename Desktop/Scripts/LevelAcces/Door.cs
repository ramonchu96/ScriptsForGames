using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    //Cambio de nivel

    public int levelID = 0;


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag("Player"))
            return;
        SceneManager.LoadScene(levelID);

    }

}
