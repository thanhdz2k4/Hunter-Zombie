using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioBase TextType;

    public void PlayTextTypeAudio() 
    {
        TextType.PlayAudio();
    }

    public void PauTextTypeAudio()
    {
        TextType.PauseAudio();
    }
}