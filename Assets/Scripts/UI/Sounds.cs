using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] STs;
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private int playNow;
    [SerializeField] private Sprite[] soundIcons;
    private UnityEngine.UI.Image button;
    private AudioSource source;
    private float volume;

    void Start()
    {
        volume = 1f;
        source = GetComponent<AudioSource>();
        button = GameObject.Find("SoundButton").GetComponent<UnityEngine.UI.Image>();
        source.clip = STs[playNow];
        source.Play();
    }

    public void PlaySound(int index, float vol)
    {
        source.PlayOneShot(sounds[index], vol * volume);
    }

    public void SoundOnOff()
    {
        if (volume == 1)
        {
            volume = 0f;
            button.sprite = soundIcons[0];
        }
        else
        {
            volume = 1f;
            button.sprite = soundIcons[1];
        }

        source.volume = 0.4f * volume;
    }

    public float GetVolume() => volume;
}
