using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveBakery : MonoBehaviour
{
	public GameObject puzzle;
	public GameObject player;

    private void OnTriggerStay(Collider other)
    {
        if (puzzle.GetComponent<LightPuzzle>().isOver && other.gameObject.name == "DialogTriggerBox2"
                && player.GetComponent<DialogSystemController>().isEmpty())
        {
            SceneManager.LoadScene("City");
        }
    }
}
