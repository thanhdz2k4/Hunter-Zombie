using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Ghoul : Enemy
{
    [SerializeField] Transform player;
    [SerializeField] float chaseDistance = 8;

    [SerializeField] Animation animation;

    protected override void Update()
    {
        base.Update();
        if(Vector3.Distance(player.position, transform.position) <= chaseDistance && stateMachine.CurrentEnemyState != chaseState)
        {
            stateMachine.ChangeState(chaseState);
            animation.Play("Run");
        }
    }

}
