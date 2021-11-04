using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Internal
    [SerializeField] private Transform cam;
    [SerializeField] private float turnSmoothTime = 0.2f;

    private Player player;
    private float turnSmoothVelocity;
    private float targetAngle;
    private float smoothAngle;
    
    // External
    public Vector3 moveDirection { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        // https://www.youtube.com/watch?v=4HpC--2iowE&ab_channel=Brackeys
        // Please check this video to understand the logic
        // Thank you
        if (player.direction.magnitude > 0.1f)
        {
            targetAngle = Mathf.Atan2(player.horizontalInput, player.verticalInput) * Mathf.Rad2Deg + cam.eulerAngles.y;    
            smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

            moveDirection = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized;
        }
    }
    #region Public Method

    #endregion
}
