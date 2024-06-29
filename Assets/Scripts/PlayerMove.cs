using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private CapsuleCollider2D collider;
    [SerializeField]
    private bool isGrounded = false;
    public LayerMask groundLayer;
    private GameObject panel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        panel = GameObject.FindGameObjectWithTag("PhysPanel");
    }

    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(collider, groundLayer);

        if (panel.transform.localScale.magnitude == 0)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Time.timeScale != 0 &&
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
}
