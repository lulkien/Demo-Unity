using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Internal
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Transform feetPos;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float feetCheckRadius;

    // External
    public float horizontalInput { get; private set; }
    public float verticalInput { get; private set; }
    public Vector3 direction { get; private set; }
    public bool isGrounded { get; private set; }

    private void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        initProperties();
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void initProperties()
    {
        rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        isGrounded = Physics.CheckSphere(feetPos.position, feetCheckRadius, groundLayerMask);
    }

    private void FixedUpdate()
    {
    }

    #region Public Method

    #endregion

}
