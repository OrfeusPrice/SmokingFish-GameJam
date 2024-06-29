using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] STs;
    [SerializeField] private int playNow;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = STs[playNow];
        source.Play();
    }

    void Update()
    {
        
    }
}
