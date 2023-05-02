using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxWrong : MonoBehaviour
{
    public static SfxWrong instance;
    public AudioClip wrongAnswer;
    private AudioSource audioSourceWrong; 
    public bool isSfxWrongOn = true;
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
        audioSourceWrong = GetComponent<AudioSource>();
        audioSourceWrong.clip = wrongAnswer;
    }
    public void ToggleSfxWrong()
    {
        isSfxWrongOn = !isSfxWrongOn;
        audioSourceWrong.volume = isSfxWrongOn ? 1 : 0;
    }

    public void WrongMessage() 
    {
        audioSourceWrong.clip = wrongAnswer;
        audioSourceWrong.Play();
    }
}
