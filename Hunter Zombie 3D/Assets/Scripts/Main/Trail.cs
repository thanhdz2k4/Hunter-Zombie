using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;


public class Trail : SpawnableGeneric<TrailRenderer>
{
    [SerializeField] float trail_Speed = 100;
    [SerializeField] TrailRenderer bullet_Trail;
    [SerializeField] Transform bullet_SpawnPoint;
    [SerializeField] LayerMask ground_Mask;
    [SerializeField] LayerMask enemy_Mask;
    [SerializeField] Vector3 bullet_Direction;
    [SerializeField] Vector3 BulletSpreadVariance = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] bool is_Add_BulletSpread = true;
    [SerializeField] ParticleSystem ImpactBloodParticleSystem;
    [SerializeField] ParticleSystem ImpactNormalParticleSystem;
    [SerializeField] GameObject aim_obj;


    public override void Initialize()
    {
        Pool = new ObjectPool<TrailRenderer>(
            createFunc: () => Instantiate(bullet_Trail),
            actionOnGet: trail => trail.gameObject.SetActive(true),
            actionOnRelease: trail => trail.gameObject.SetActive(false),
            actionOnDestroy: trail => Destroy(trail.gameObject),
            collectionCheck: false,
            defaultCapacity: 10
        );
    }

    private void LateUpdate()
    {
        //direction_Spawn = GetDirection();
        Vector3 direction = (aim_obj.transform.position - bullet_SpawnPoint.position).normalized;
        //Debug.DrawLine(bullet_SpawnPoint.position, direction, Color.red);
        Debug.DrawLine(bullet_SpawnPoint.position, bullet_SpawnPoint.position + direction * 5, Color.red);
    }

    public override void Spawn()
    {
        SpawnTrail();
    }

    private void SpawnTrail()
    {
         Vector3 direction = GetDirection(); // Get the calculated direction

    // Perform a raycast to detect what the bullet hits
    if (Physics.Raycast(bullet_SpawnPoint.position, direction, out RaycastHit hit, Mathf.Infinity, ground_Mask | enemy_Mask))
    {
        // If the raycast hits something, spawn the trail towards the hit point
        StartCoroutine(SpawnTrail(GetTrail(), hit.point, hit.normal, true, hit.collider.gameObject.layer, hit.collider));
    }
    else
    {
        // If the raycast hits nothing, spawn the trail in the calculated direction to a maximum distance
        StartCoroutine(SpawnTrail(GetTrail(), bullet_SpawnPoint.position + direction * 100, Vector3.zero, false, ground_Mask, null));
    }
       
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, Vector3 HitPoint, Vector3 HitNormal, bool MadeImpact, LayerMask layerMask, Collider collider)
    {
        // Distance calculation

        Vector3 startPosition = Trail.transform.position;
        float distance = Vector3.Distance(Trail.transform.position, HitPoint);
        float remainingDistance = distance;

        // get closer to hit
        while (remainingDistance > 0)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, HitPoint, 1 - (remainingDistance / distance));

            remainingDistance -= trail_Speed * Time.deltaTime;

            yield return null;
        }

        Trail.transform.position = HitPoint;

        Impact_VFX(HitPoint, HitNormal, MadeImpact, layerMask, collider);

        Pool.Release(Trail);
    }

    private void Impact_VFX(Vector3 HitPoint, Vector3 HitNormal, bool MadeImpact, LayerMask layerMask, Collider collider)
    {
        if (MadeImpact)
        {
            if (layerMask == LayerMask.NameToLayer("Enemy") && ImpactBloodParticleSystem != null)
            {
                //Instantiate(ImpactBloodParticleSystem, HitPoint, Quaternion.LookRotation(HitNormal));
                collider.GetComponent<IGetDamage>().GetDamage(1);
            }
            else if (ImpactNormalParticleSystem != null)
            {
                Instantiate(ImpactNormalParticleSystem, HitPoint, Quaternion.LookRotation(HitNormal));
            }
        }
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = (aim_obj.transform.position - bullet_SpawnPoint.position).normalized;
        if (is_Add_BulletSpread)
        {
            direction += new Vector3(
                Random.Range(-BulletSpreadVariance.x, BulletSpreadVariance.x),
                Random.Range(-BulletSpreadVariance.y, BulletSpreadVariance.y),
                Random.Range(-BulletSpreadVariance.z, BulletSpreadVariance.z)
            );

            direction.Normalize();
        }
        Vector3 x =  direction.normalized;
        return x;
    }

    private TrailRenderer GetTrail()
    {
        TrailRenderer trail = Pool.Get(); // Get trail from pool
        trail.transform.position = bullet_SpawnPoint.position; // Set initial position
        return trail;
    }

}
