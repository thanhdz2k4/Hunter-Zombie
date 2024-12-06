using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioBase : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip audioClip;



    public abstract void  PlayAudio();
    public abstract void  PauseAudio();
}
