using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;

    AudioSource audioSource;
    public AudioClip backgroundMusic;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        //print("new Instance");
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    private void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
