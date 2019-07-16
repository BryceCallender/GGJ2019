using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 rotation = new Vector2(0, 0);
    public float speed = 2;

    public float minX = -180.0f;
    public float maxX = 180.0f;

    public float minY = 0.0f;
    public float maxY = 10.0f;

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X");
        //rotation.x += -Input.GetAxis("Mouse Y");

        rotation.y = Mathf.Clamp(rotation.y, minY, maxY);
        //rotation.x = Mathf.Clamp(rotation.x, minX, maxX);

        transform.eulerAngles = rotation * speed;
    }
}
