using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public GameObject[] paused_objects;
    GameObject player;


    public void Begin_Game()
    {
        SceneManager.LoadScene("City");
    }

    public void Options()
    {
     	SceneManager.LoadScene("Options Menu");   
    }

    public void Back()
    {
    	SceneManager.LoadScene("Main Menu");
    }

    public void TestScene(){
        SceneManager.LoadScene("TestScene");
    }

    public void Quit()
    {
    	Application.Quit();
    }

    void Start()
    {
        Time.timeScale = 1;
        paused_objects = GameObject.FindGameObjectsWithTag("ShowOnPaused");
        hidePaused();
        player = GameObject.Find("Capsule");
        player.GetComponent<PlayerMovement>().enabled = true;
    }

    void Update(){
        if (Input.GetKeyDown("escape"))
        {
            pause_all();
        }
    }

    //------
    // Helper Functions
    //------
    //shows objects with ShowOnPause tag
    public void showPaused(){
        foreach(GameObject g in paused_objects){
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused(){
        foreach(GameObject g in paused_objects){
            g.SetActive(false);
        }
    }

    void pause_all()
    {
        if (Time.timeScale == 1){
            Time.timeScale = 0;
            showPaused();
            player.GetComponent<PlayerMovement>().enabled = false;
        }
        else if (Time.timeScale == 0){
            Time.timeScale = 1;
            hidePaused();
            player.GetComponent<PlayerMovement>().enabled = true;
            //player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
