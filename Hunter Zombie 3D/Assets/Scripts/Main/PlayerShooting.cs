using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GunSO gunSO;
    [SerializeField] Animator animator;
    [SerializeField] int buttet_Quantity;
    [SerializeField] float fireRate = 0.1f;
    [SerializeField]  bool isReload;
    [SerializeField] Playable Gun_Behaviour;
    float nextFireTime;
    // Start is called before the first frame update
    void Start()
    {
        buttet_Quantity = gunSO.Buttlet_Quantity;
    }

    void Update()
    {
        ShootingAnmation();
         
    }

    void LateUpdate()
    {
       ShootingBullet();
    }

    private void ShootingBullet()
    {
        Gun_Behaviour.IsPlay(!isReload);

    }


    private void ShootingAnmation()
    {
        if(!isReload)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (buttet_Quantity > 0)
                {
                    ShootAnimation();
                }
            }


            if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFireTime)
            {
                if (buttet_Quantity > 0)
                {
                    nextFireTime = Time.time + fireRate;
                    ShootAnimation();
                }
            }

        }
        Reload();

    }
    public void MinusBullet()
    {
        buttet_Quantity--;
    }

    private void ShootAnimation()
    {
        animator.SetTrigger("Shoot");
    }
    private void Reload()
    {
        if (buttet_Quantity <= 0)
        {
            animator.SetBool("Reloading", true);
            isReload = true;
        }
        else
        {
            animator.SetBool("Reloading", false);
            isReload = false;
        }
    }

    public void ReloadBullet()
    {
        buttet_Quantity = gunSO.Buttlet_Quantity;
        animator.SetBool("Reloading", false);
    }
}
