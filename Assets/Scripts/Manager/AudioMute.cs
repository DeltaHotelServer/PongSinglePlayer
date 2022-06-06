using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMute : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            audioSource.volume = 0;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            audioSource.volume = 1;
        }
    }
}
