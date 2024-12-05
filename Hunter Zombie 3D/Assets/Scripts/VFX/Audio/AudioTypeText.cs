using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTypeText : AudioBase
{
    private void Start()
    {
        audioSource.clip = audioClip;
    }

    public override void PlayAudio()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public override void PauseAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
}
