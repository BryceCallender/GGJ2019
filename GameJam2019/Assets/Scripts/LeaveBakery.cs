using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveBakery : MonoBehaviour
{

	public GameObject puzzle;
    
    void OnTriggerEnter(Collider other)
    {
    	if (puzzle.GetComponent<LightPuzzle>().isOver){
    		SceneManager.LoadScene("City");
    	}
    }
}
