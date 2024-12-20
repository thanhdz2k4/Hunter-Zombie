using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Ghoul : Enemy
{
    [SerializeField] Transform player;
    [SerializeField] float chaseDistance = 8;
    [SerializeField] Animation animation;

    #region Attack variable
    [SerializeField] float attackDistance = 2;
    [SerializeField] float timerAttack = 2;
    float timer;
    #endregion

    protected override void Update()
    {
        base.Update();
         // Check if the enemy is within the chase range and not already chasing
    if(stateMachine.CurrentEnemyState == attackState && Vector3.Distance(player.position, transform.position) > attackDistance) {

         timer += Time.deltaTime;
         if(timer >= timerAttack)
         {
            if(stateMachine.CurrentEnemyState != chaseState) {
                stateMachine.ChangeState(chaseState);
            animation.Play("Run");
            }
            timer = 0;
         }

    }
    if (Vector3.Distance(player.position, transform.position) <= chaseDistance && stateMachine.CurrentEnemyState != chaseState && stateMachine.CurrentEnemyState != attackState)
    {
        
        // Ensure the enemy is not in attack range before switching to chase
        if (Vector3.Distance(player.position, transform.position) > attackDistance)
        {
            stateMachine.ChangeState(chaseState);
            animation.Play("Run");
        }
    }

    // Check if the enemy is within attack range and not already attacking
    if (Vector3.Distance(player.position, transform.position) <= attackDistance && stateMachine.CurrentEnemyState != attackState)
    {
        stateMachine.ChangeState(attackState);
        animation.Play("Attack2");
        
    }
        
    }

   

}
