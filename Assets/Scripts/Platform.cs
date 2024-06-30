using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float xmin;
    [SerializeField] private float xmax;
    [SerializeField] private float ymin;
    [SerializeField] private float ymax;

    private float horizontal;
    private float vertical;

    private bool goToP1;
    private bool goToP2;

    private float form;
    private float speed;
    private Rigidbody2D rb;

    void Start()
    {
        goToP1 = false;
        goToP2 = true;

        form = 0f;
        horizontal = ymin == ymax ? 1 : 0;
        vertical = horizontal == 1 ? 0 : 1;

        speed = 2f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (goToP2)
        {
            transform.Translate(new Vector3(speed * horizontal * form * Time.deltaTime, speed * vertical * form * Time.deltaTime, 0));

            if (horizontal == 1)
            {
                if (transform.position.x > xmax)
                {
                    goToP1 = true;
                    goToP2 = false;
                }
            }
            else
            {
                if (transform.position.y > ymax)
                {
                    goToP1 = true;
                    goToP2 = false;
                }
            }
        }
        else if (goToP1)
        {
            transform.Translate(new Vector3(-speed * horizontal * form * Time.deltaTime, -speed * vertical * form * Time.deltaTime, 0));

            if (horizontal == 1)
            {
                if (transform.position.x < xmin)
                {
                    goToP1 = false;
                    goToP2 = true;
                }
            }
            else
            {
                if (transform.position.y < ymin)
                {
                    goToP1 = false;
                    goToP2 = true;
                }
            }
        }
    }

    public void SetActive()
    {
        form = 1f;
        Debug.Log("ACTIVATED");
    }
}
