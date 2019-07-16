using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BakerySceneLoad : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public GameObject lightPuzzle;
    public GameObject swapPuzzle;

    [SerializeField]
    private Transform playerStartPosition;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name);

        player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = playerStartPosition.position;

        DialogSystemController playerPuzzle = player.GetComponent<DialogSystemController>();

        swapPuzzle.GetComponent<SwappingPuzzle>().player = player;
        lightPuzzle.GetComponent<LightPuzzle>().player = player;
        
        playerPuzzle.swapPuzzle = swapPuzzle;
        playerPuzzle.lightPuzzle = lightPuzzle;
    }
}
