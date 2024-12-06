using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioBase TextType;

    public static AudioManager instance;

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

    public void PlayTextTypeAudio() 
    {
        TextType.PlayAudio();
    }

    public void PauTextTypeAudio()
    {
        TextType.PauseAudio();
    }
}