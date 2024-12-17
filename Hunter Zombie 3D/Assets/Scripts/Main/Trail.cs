using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Trail : SpawnableGeneric<TrailRenderer>
{
    [SerializeField] float trail_Speed = 100;
    [SerializeField] TrailRenderer bullet_Trail;
    [SerializeField] Transform bullet_SpawnPoint;
    [SerializeField] LayerMask ground_Mask;
    [SerializeField] LayerMask enemy_Mask;

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
        
    }

    private void SpawnTrail(TrailRenderer trailRenderer)
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

    private void SpawnImpact(Vector3 hitPoint, Vector3 hitNormal, bool madeImpact, LayerMask layerMask)
    {
        throw new NotImplementedException();
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = new Vector3(1,1,1);
        
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
