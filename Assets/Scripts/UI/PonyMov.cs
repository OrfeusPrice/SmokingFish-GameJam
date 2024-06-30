using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonyMov : MonoBehaviour
{
    private Sounds soundManager;

    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<Sounds>();
    }
    private void Update()
    {
        soundManager.SetMusic(1);
        Destroy(gameObject);
    }
}
