using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPatrolState : EnemyState
{
    List<Transform> points;
    Transform currentPoint;
    float speed = 0.2f;
    float smoothSpeed = 1f;


    public EnemyPatrolState(Enemy enemy, EnemyStateMachine enemyStateMachine, List<Transform> points) : base(enemy, enemyStateMachine) 
    {
        this.points = points;

    }
    public override void AnimationTriggerEvent(EnemyTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
         GetRandomPoint();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        // Tính hướng
        Vector3 direction = (currentPoint.position - enemy.transform.position).normalized;

        // Di chuyển theo hướng tọa độ thế giới
        enemy.transform.position += direction * enemy.PatrolSpeed * Time.deltaTime;

        // Kiểm tra khoảng cách
        if (Vector3.Distance(currentPoint.position, enemy.transform.position) < 2f)
        {
            Transform lastPoint = currentPoint;
            GetRandomPoint();

            // Đảm bảo không thêm điểm lại ngay lập tức
            if (lastPoint != currentPoint)
                points.Add(lastPoint);
        }

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

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override string ToString()
    {
        return base.ToString();
    }


    private Transform GetRandomPoint()
    {
        currentPoint = points[Random.Range(0, points.Count)];
        points.Remove(currentPoint);
        return currentPoint;
    }

}
