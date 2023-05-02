using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip backgroundMusic;
    private AudioSource audioSource;
    public bool isSoundOn = true;
     void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
     void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        audioSource.volume = isSoundOn ? 1 : 0;
    }
}
