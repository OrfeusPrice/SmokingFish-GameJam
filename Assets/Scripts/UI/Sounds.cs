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
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundSource;
    //private Volume v;
    private UnityEngine.UI.Image button;
    private AudioSource source;
    private float volume;

    void Start()
    {
        //v = GameObject.Find("Volume").GetComponent<Volume>();
        source = GetComponent<AudioSource>();
        button = GameObject.Find("SoundButton").GetComponent<UnityEngine.UI.Image>();
        musicSource.clip = STs[playNow];
        volume = 1f;
        //volume = v.GetVolume();
        musicSource.Play();
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(int index, float vol)
    {
        soundSource.PlayOneShot(sounds[index], vol * volume);
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

        //v.SetVolume(volume);
        musicSource.volume = 0.4f * volume;
    }

    public float GetVolume() => volume;
}
