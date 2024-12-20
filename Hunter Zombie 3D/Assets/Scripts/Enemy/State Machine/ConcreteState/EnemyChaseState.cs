using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    Transform player;
    float smoothSpeed = 8f;

    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Chase state");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        
        Vector3 direction = (player.position - enemy.transform.position).normalized;
        
        enemy.transform.position += direction * enemy.ChasingSpeed * Time.deltaTime;

        Rotate(direction);

    }

    private void Rotate(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        Vector3 eulerAngles = rotation.eulerAngles;
        eulerAngles.x = 0; // Set the x component to 0
        rotation = Quaternion.Euler(eulerAngles); // Reassign the modified Euler angles back to the quaternion
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, rotation, Time.deltaTime * smoothSpeed);
    }

}
