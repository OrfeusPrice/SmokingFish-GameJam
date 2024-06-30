using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Volume : MonoBehaviour
{
    private float volume;

    void Start()
    {
        volume = 1f;
        DontDestroyOnLoad(gameObject);
    }

    public float GetVolume() => volume;
    public void SetVolume(float vol) => volume = vol;
}
