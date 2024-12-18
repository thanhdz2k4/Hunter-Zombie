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


    Vector3 direction_Spawn;

    


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

    public override void Spawn()
    {
        direction_Spawn = GetDirection();
        SpawnTrail();
    }

    private void SpawnTrail()
    {
        if (Physics.Raycast(bullet_SpawnPoint.position, direction_Spawn, out RaycastHit hit, float.MaxValue, ground_Mask))
        {
            
            StartCoroutine(SpawnTrail(GetTrail(), hit.point, hit.normal, true, ground_Mask));
        }
        if (Physics.Raycast(bullet_SpawnPoint.position, direction_Spawn, out RaycastHit hit1, float.MaxValue, enemy_Mask))
        {

            StartCoroutine(SpawnTrail(GetTrail(), hit1.point, hit1.normal, true, enemy_Mask));
        }

        else
        {
            StartCoroutine(SpawnTrail(GetTrail(), bullet_SpawnPoint.position + GetDirection() * 100, Vector3.zero, false, ground_Mask));   
        }
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, Vector3 HitPoint, Vector3 HitNormal, bool MadeImpact, LayerMask layerMask)
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
        SpawnImpact(HitPoint, HitNormal, MadeImpact, layerMask);

        Pool.Release(Trail);
    }

    private void SpawnImpact(Vector3 HitPoint, Vector3 HitNormal, bool MadeImpact, LayerMask hitLayer)
    {
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int groundLayer = LayerMask.NameToLayer("Ground");
        Debug.Log("SpawnImpact");

        // Check if the impact happened on the "Enemy" layer
        if (MadeImpact && (hitLayer & (1 << enemyLayer)) != 0)
        {
            Instantiate(ImpactBloodParticleSystem, HitPoint, Quaternion.LookRotation(HitNormal));
            Debug.Log("Enemy impact");
        }

        // Check if the impact happened on the "Ground" layer
        if (MadeImpact && (hitLayer & (1 << groundLayer)) != 0)
        {
            Instantiate(ImpactNormalParticleSystem, HitPoint, Quaternion.LookRotation(HitNormal));
            Debug.Log("Ground impact");
        }
    }

    private Vector3 GetDirection()
    {
         Vector3 direction = bullet_SpawnPoint.up * -1 + bullet_Direction;
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
