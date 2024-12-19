using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGetDamage : MonoBehaviour, IGetDamage
{
    [SerializeField] ParticleSystem Get_Damage_VFX;
    [SerializeField] string nameOfDamge;
    [SerializeField] Transform spawn_Damge_VFX_Position;
    [SerializeField] Vector3 Rotation_Damge_VFX;
    [SerializeField] int health;


    public void GetDamage(int Damage)
    {
        SpawnVFX();
        health -= Damage;
    }

    

    public void SpawnVFX()
    {
        Instantiate(Get_Damage_VFX, spawn_Damge_VFX_Position.position, Quaternion.Euler(0, Random.Range(180, 20), 0)).gameObject.transform.SetParent(spawn_Damge_VFX_Position);
    }
}
