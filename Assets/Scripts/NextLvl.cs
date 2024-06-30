using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{
    public string nameOfLvl = "";

    private void Start()
    {
        if (nameOfLvl == "")
            nameOfLvl = "Tutorial";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SceneManager.LoadScene(nameOfLvl);

    }
}
