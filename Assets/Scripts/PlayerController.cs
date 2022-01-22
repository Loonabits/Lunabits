using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 50f;

    private Rigidbody2D r2d;

    private PlayerControls playerControls;

    public Collider2D col;

    [SerializeField]
    private LayerMask ground;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        r2d = this.GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
        col = this.GetComponent<Collider2D>();
    }

    void Start()
    {
        playerControls.Land.Jump.performed += _ => Jump();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        float movementInput = playerControls.Land.Move.ReadValue<float>();
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;
    }

    private void Jump()
    {
        if (isGrounded()) 
        {
            r2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private bool isGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= col.bounds.extents.x;
        topLeftPoint.y += col.bounds.extents.y;

        Vector2 bottomRight = transform.position;
        bottomRight.x += col.bounds.extents.x;
        bottomRight.y -= col.bounds.extents.y;

        return Physics2D.OverlapArea(topLeftPoint, bottomRight, ground);
    }



}
