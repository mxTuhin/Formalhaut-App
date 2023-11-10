using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]private AudioSource audioSource;
    
    private static AudioManager instance;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip error;
    
    public static AudioClip GetButtonClick => instance.buttonClick;
    public static AudioClip GetError => instance.error;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetSFXSound();
    }

    public static void PlaySFX(AudioClip clip)
    {
        instance.audioSource.PlayOneShot(clip);
    }

    private void SetSFXSound()
    {
        audioSource.volume = 0.5f;
    }
    
    public static AudioManager GetInstance()
    {
        return instance;
    }
}
