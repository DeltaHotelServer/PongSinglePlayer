using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMute : MonoBehaviour
{
    public AudioListener audioListener;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            audioListener.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            audioListener.enabled = true;
        }
    }
}
