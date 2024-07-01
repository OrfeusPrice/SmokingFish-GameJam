using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonyMov : MonoBehaviour
{
    private Sounds soundManager;
    [SerializeField] private int playNow;

    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<Sounds>();
    }
    private void Update()
    {
        soundManager.SetMusic(playNow);
        Destroy(gameObject);
    }
}
