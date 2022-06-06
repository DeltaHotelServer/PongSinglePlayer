using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    
    private AudioSource[] mySounds;

    public AudioSource paddelSound;
    public AudioSource goalSound;

    [SerializeField]
    private void Start()
    {
        AudioSource audioSource1 = GetComponent<AudioSource>();

        paddelSound = mySounds[1];
        goalSound = mySounds[2];
    }

    public void PlayPaddleSound()
    {
        paddelSound.Play();
    }

    public void PlayGoalSound()
    {
        goalSound.Play();
    }



}
