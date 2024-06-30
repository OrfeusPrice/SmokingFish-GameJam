using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public GameObject cam;

    float startPosX;
    float startPosY;

    public float parallax;

    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    void Update()
    {
        float distX = (cam.transform.position.x * (1 - parallax));
        float distY = (cam.transform.position.y * (1 - parallax));
        //transform.position = new Vector3 (startPosX + distX, transform.position.y, transform.position.z);
        transform.position = new Vector3 (startPosX + distX, startPosY + distY, transform.position.z);
    }
}
