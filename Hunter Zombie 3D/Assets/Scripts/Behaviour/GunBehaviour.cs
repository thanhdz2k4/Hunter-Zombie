using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : Playable
{
    [SerializeField] SpawnableGeneric<TrailRenderer> spawnable;
    private float LastShootTime;
    [SerializeField]
    private float fireRate;

    
    public override void IsPlay(bool isPlay)
    {
        if (isPlay)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                spawnable.Spawn();
            }
            if (Input.GetKey(KeyCode.Mouse0) && Time.time > LastShootTime)
            {

                LastShootTime = Time.time + fireRate;

                spawnable.Spawn();

            }
        }
    }
}
