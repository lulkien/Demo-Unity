using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravityAcceleration;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Transform feetCheck;
    [SerializeField] private float feetRadius = 0.1f;

    private Vector3 surface_velocity;
    private Vector3 height_velocity;
    private bool isGrounded = false;

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics.CheckSphere(feetCheck.position, feetRadius, groundLayerMask);
        if (isGrounded && height_velocity.y < 0)
        {
            height_velocity.y = -2f;    // Trick
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        surface_velocity = transform.right * x + transform.forward * y;
        controller.Move(surface_velocity * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            height_velocity.y += Mathf.Sqrt(2 * jumpHeight * gravityAcceleration);
        }
        height_velocity.y += (-1) * gravityAcceleration * Time.deltaTime;
        controller.Move(height_velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {

    }
}
