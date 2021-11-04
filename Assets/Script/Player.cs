using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayerMask;
    private Rigidbody rigidBody;
    private BoxCollider boxCollider;

    private bool shouldJump = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldJump == false)
        {
            shouldJump = Input.GetKeyDown(KeyCode.Space);
        }
    }

    private void FixedUpdate()
    {
        if (shouldJump && isGrounded())
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            shouldJump = false;
        }
    }

    private bool isGrounded()
    {
        float maxDistance = transform.localScale.y;
        bool isHit = Physics.BoxCast(transform.position, Vector3.zero, Vector3.down, Quaternion.identity, maxDistance, groundLayerMask);
        return isHit;
    }
}
