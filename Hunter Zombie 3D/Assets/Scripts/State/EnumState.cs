using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieStateID
{
    None = 0,
    Patrolling,
    Follow,
    Attack1,
    Attack2,
    Death,
    Idle,

}

public enum EnemyTriggerType 
{
    EnemyDamged,
    PlayFootstepSound
}

public class EnumState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
