using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    private EnemyState currentEnemyState { get; set; }
    public EnemyState CurrentEnemyState
    {
        get => currentEnemyState;
        set
        {
            if (value == null)
                Debug.LogError("CurrentEnemyState is being set to null!");
            currentEnemyState = value;
            Debug.Log($"CurrentEnemyState changed to: {currentEnemyState}");
        }
    }

    public void Initialize(EnemyState startingState)
    {
        if (startingState == null)
        {
            Debug.LogError("Starting state is null in Initialize!");
            return;
        }
        currentEnemyState = startingState;
        currentEnemyState.EnterState();
    }


    public void ChangeState(EnemyState newState)
    {
        currentEnemyState.ExitState();
        currentEnemyState = newState;
        currentEnemyState.EnterState();
    }
}
