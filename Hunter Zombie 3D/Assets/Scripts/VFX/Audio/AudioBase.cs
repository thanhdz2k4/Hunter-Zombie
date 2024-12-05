using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioBase : MonoBehaviour
{
    public static AudioBase instance;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip audioClip;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public abstract void  PlayAudio();
    public abstract void  PauseAudio();
}
