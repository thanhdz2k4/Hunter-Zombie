using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGetDamage : MonoBehaviour, IGetDamage
{
    [SerializeField] ParticleSystem Get_Damage_VFX;
    [SerializeField] Transform spawn_Damge_VFX_Position;
    [SerializeField] int health;
    [SerializeField] Playable TextFloating;

    public void GetDamage(int Damage)
    {
        SpawnVFX();
        health -= Damage;
        TextFloating.IsPlay(true);
    }

    
    public void SpawnVFX()
    {
        Instantiate(Get_Damage_VFX, spawn_Damge_VFX_Position.position, Quaternion.Euler(0, Random.Range(180, 20), 0)).gameObject.transform.SetParent(spawn_Damge_VFX_Position);
    }

    
}
