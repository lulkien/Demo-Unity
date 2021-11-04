using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Modify in Unity
    [SerializeField] private CharacterController controller;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float gravityAcceleration;

    // Real private
    private Player player;
    private PlayerRotation playerRotation;
    private Vector3 upVelocity;


    private void Start()
    {
        player = gameObject.GetComponent<Player>();
        playerRotation = gameObject.GetComponent<PlayerRotation>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (upVelocity.y < 0 && player.isGrounded)
        {
            upVelocity.y = -4f;    // Trick to force player put his god damn feet into ground
        }

        if (player.direction.magnitude > 0.1f)
        {
            controller.Move(playerRotation.moveDirection * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded) 
        {
            upVelocity.y += Mathf.Sqrt(2 * jumpPower * gravityAcceleration);
        }
        upVelocity.y += (-2f) * gravityAcceleration * Time.deltaTime;
        controller.Move(upVelocity * Time.deltaTime);
    }

}
