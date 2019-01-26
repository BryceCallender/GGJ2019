using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;
    public string sceneName;

	public static MusicManager Instance
	{
        get { return instance; }
    }

    void Start()
    {
    	sceneName = SceneManager.GetActiveScene().name;

    	if (sceneName != "Main Menu"){
    		DontDestroyOnLoad(this.gameObject);
    	}
    	if (sceneName != "Options Menu"){
    		DontDestroyOnLoad(this.gameObject);
    	}
    	else{
    		Destroy(this.gameObject);
    	}
    	
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
    	Debug.Log(scene.name);
    	if (scene.name == "TestScene"){
    		Destroy(this.gameObject);
    	}
    }

    void Awake()
    {
    	SceneManager.sceneLoaded += OnSceneLoaded;

        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        
     }
}
