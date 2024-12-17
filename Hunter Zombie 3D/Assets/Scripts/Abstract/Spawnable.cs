using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawnable : MonoBehaviour
{
    [SerializeField]
    protected GameObject Object_Spawn;

    public abstract void Initialize();
    public abstract void Spawn();
    
}
