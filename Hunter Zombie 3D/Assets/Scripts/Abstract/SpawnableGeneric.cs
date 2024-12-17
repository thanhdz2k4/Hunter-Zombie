using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnableGeneric<T> : MonoBehaviour where T : Component
{
    protected ObjectPool<T> Pool;

    public virtual void Initialize()
    {
        //Pool = new ObjectPool<T>();
    }

    public virtual void Spawn()
    {
       
    }
}