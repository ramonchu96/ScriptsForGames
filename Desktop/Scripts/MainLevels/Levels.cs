using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    //Cambio de nivel

  


    public void Level01()
    {
        SceneManager.LoadScene("Level01", LoadSceneMode.Single);
    }
    public void Level02()
    {
        SceneManager.LoadScene("Level02", LoadSceneMode.Single);
    }
    public void Level03()
    {
        SceneManager.LoadScene("Level03");
    }
    public void Level04()
    {
        SceneManager.LoadScene("Level04");
    }
    public void Level05()
    {
        SceneManager.LoadScene("Level05");
    }


}
