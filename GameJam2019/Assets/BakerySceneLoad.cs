using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BakerySceneLoad : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Transform playerStartPosition;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name);

        player = GameObject.FindWithTag("Player");

        player.transform.position = playerStartPosition.position;
    }
}
