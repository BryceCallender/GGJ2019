using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwapScript : MonoBehaviour
{
    public Camera mainCamera;
    public Camera puzzleCamera;

    public bool usingMainCamera = true;

    private static CameraSwapScript instance = null;

    public static CameraSwapScript Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }

    public void SwitchCamera()
    {
        if(usingMainCamera)
        {
            mainCamera.gameObject.SetActive(false);
            puzzleCamera.gameObject.SetActive(true);
            usingMainCamera = false;
        }
        else
        {
            puzzleCamera.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
            usingMainCamera = true;
        }
    }
}
