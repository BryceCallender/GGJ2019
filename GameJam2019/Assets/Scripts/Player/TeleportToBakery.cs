using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToBakery : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
    	if (other.gameObject.name == "TeleportCube" 
    		&& player.GetComponent<DialogSystemController>().isEmpty())
    	{
    		SceneManager.LoadScene("InsideBakery");
    	}
    }
}
