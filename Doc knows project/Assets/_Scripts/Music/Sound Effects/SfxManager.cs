using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager instance;
    public AudioClip correctAnswer;
    private AudioSource audioSourceCorrect;
    public bool isSfxCorrectOn = true;
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
        audioSourceCorrect = GetComponent<AudioSource>();
        audioSourceCorrect.clip = correctAnswer;
    }
    public void ToggleSfxCorrect() 
    {
        isSfxCorrectOn = !isSfxCorrectOn;
        audioSourceCorrect.volume = isSfxCorrectOn ? 1 : 0; 
    }

    public void CorrectMessage()
    {
        audioSourceCorrect.clip = correctAnswer;
        audioSourceCorrect.Play();
    }
}
