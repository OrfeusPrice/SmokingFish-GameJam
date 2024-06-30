using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    public BoxCollider2D collider;
    [SerializeField]
    private bool isGrounded = false;
    public LayerMask groundLayer;
    private GameObject panel;
    private Sounds soundManager;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundManager = GameObject.Find("SoundManager").GetComponent<Sounds>();
        rb = GetComponent<Rigidbody2D>();
        //collider = GetComponent<BoxCollider2D>();
        panel = GameObject.FindGameObjectWithTag("PhysPanel");
    }

    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(collider, groundLayer);

        if (!isGrounded)
        {
            GetComponent<Animator>().SetBool("isJump", true);
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
        else GetComponent<Animator>().SetBool("isJump", false);

        if (soundManager.GetVolume() == 0)
            audioSource.Stop();

        if (panel.transform.localScale.magnitude == 0)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

            if (horizontalInput != 0)
            {
                if (soundManager.GetVolume() == 1 && !audioSource.isPlaying)
                    audioSource.Play();
                GetComponent<Animator>().SetBool("isRun", true);
            }
            else
            {
                audioSource.Stop();
                GetComponent<Animator>().SetBool("isRun", false);
            }

            if (horizontalInput < 0) GetComponent<SpriteRenderer>().flipX = true;
            else if (horizontalInput > 0) GetComponent<SpriteRenderer>().flipX = false;

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Time.timeScale != 0 &&
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
}
