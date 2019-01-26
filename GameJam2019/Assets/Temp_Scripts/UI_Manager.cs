using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public void Begin_Game()
    {
        //SceneManager.LoadScene("");
    }

    public void Options()
    {
     	SceneManager.LoadScene("Options Menu");   
    }

    public void Back()
    {
    	SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
    	Application.Quit();
    }
}
