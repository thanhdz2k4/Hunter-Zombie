using UnityEngine;
using System.Collections;
using UnityEngine.Playables;

[RequireComponent(typeof(Light))]
public class WFX_LightFlicker : MonoBehaviour, IPlayable
{
    public float time = 0.5f; 
    public float flickerInterval = 0.05f; 

    private Light lightComponent;

    void Start()
    {
        lightComponent  = GetComponent<Light>();
        lightComponent.enabled = false; 
    }

    private IEnumerator Flicker()
    {
        float elapsed = 0f; 

        while (elapsed < time)
        {
            lightComponent.enabled = !lightComponent.enabled; 
            yield return new WaitForSeconds(flickerInterval);
            elapsed += flickerInterval; 
        }

        lightComponent.enabled = false; 
    }

    public void Playable(bool isPlay)
    {
        if (isPlay)
        {
            StopAllCoroutines(); 
            StartCoroutine(Flicker());
        }
    }

    public PlayableHandle GetHandle()
    {
        throw new System.NotImplementedException();
    }
}
