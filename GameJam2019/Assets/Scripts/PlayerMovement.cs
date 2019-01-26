using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float playerWalkSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0.0f, moveZ);

        moveDirection.Normalize();

        Vector3 newPosition = rb.position + (moveDirection * playerWalkSpeed * Time.deltaTime);

        rb.MovePosition(newPosition);
    }
}
