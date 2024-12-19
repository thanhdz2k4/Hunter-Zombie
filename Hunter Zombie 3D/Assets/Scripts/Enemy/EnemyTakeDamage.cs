using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour, ITakeDamage
{
    [SerializeField] ParticleSystem TakeDamgeVFX;
    [SerializeField] string nameOfDamage;
    
    public int TakeDamage()
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if(collision.gameObject.tag == nameOfDamage)
        {
            TakeDamage()
        }*/
    }





}
