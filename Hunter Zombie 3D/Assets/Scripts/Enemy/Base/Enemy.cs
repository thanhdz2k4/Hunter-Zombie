using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    #region State Machine Variable
    protected EnemyStateMachine stateMachine { get; private set; }
    protected EnemyPatrolState patrolState { get; private set; }
    protected EnemyChaseState chaseState { get; private set; }
    protected EnemyAttackState attackState { get; private set; }
    #endregion

    #region Patrol area
    [SerializeField] protected float patrolSpeed;
    public float PatrolSpeed {get => patrolSpeed;  }
    [SerializeField] List<Transform> points;
    #endregion

    #region  Chasing variable
    [SerializeField] protected float chasingSpeed;
    public float ChasingSpeed {get => chasingSpeed;}
    #endregion

    protected virtual void Awake()
    {
        stateMachine = new EnemyStateMachine();
        patrolState = new EnemyPatrolState(this, stateMachine, points);
        chaseState = new EnemyChaseState(this, stateMachine);
        attackState = new EnemyAttackState(this, stateMachine);
    }

    protected virtual void Start()
    {
        stateMachine.Initialize(patrolState);
        
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        stateMachine.CurrentEnemyState.FrameUpdate();
    }

    protected virtual void FixedUpdate()
    {
        stateMachine.CurrentEnemyState.PhysicsUpdate();
    }


    protected virtual void AnimationTriggerEvent(EnemyTriggerType triggerType)
    {
        stateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }
}
