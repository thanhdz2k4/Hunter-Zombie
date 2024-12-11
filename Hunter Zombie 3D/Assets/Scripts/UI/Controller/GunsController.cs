using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunsController : MonoBehaviour
{
    public static event Action<List<GunSO>> FilterGunsEvent;
    [SerializeField] List<GunSO> gunSOs = new List<GunSO>();

    private void Start()
    {
        StartCoroutine(InvokeFilterGunsEvent());
    }

    private IEnumerator InvokeFilterGunsEvent()
    {
        yield return null; // Wait for one frame to ensure subscriptions
        FilterGunsEvent?.Invoke(gunSOs);
    }
    
}
