using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public int nextSceneLoad;


    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter2D(Collider2D doorLevel)
    {
        if(doorLevel.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneLoad);

            if(nextSceneLoad > PlayerPrefs.GetInt("LevelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }

        }
    }
}
