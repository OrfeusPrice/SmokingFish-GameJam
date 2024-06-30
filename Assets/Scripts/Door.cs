using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private float maxpath;
    private float currpath;
    private float form;
    private float speed;
    private bool activated;
    
    void Start()
    {
        activated = false;
        currpath = 0;
        maxpath = 4.5f;
        form = 0f;
        speed = 2f;
    }

    void Update()
    {
        currpath += speed * form * Time.deltaTime;
        transform.Translate(new Vector3(0, -speed * form * Time.deltaTime, 0));
        if (currpath > maxpath)
            form = 0f;
    }

    public void SetActive()
    {
        form = 1f;
        activated = true;
        Debug.Log("ACTIVATED");
    }
}
