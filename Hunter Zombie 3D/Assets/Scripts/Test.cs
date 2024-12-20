using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    List<Transform> points;
    [SerializeField] Transform currentPoint;
    [SerializeField] float speed = 0.2f;
    [SerializeField] float smoothSpeed = 1f;

    private void Start()
    {
        GetRandomPoint();
    }

    private void Update()
    {
        // Tính hướng
        Vector3 direction = (currentPoint.position - transform.position).normalized;

        // Di chuyển theo hướng tọa độ thế giới
        transform.position += direction * speed * Time.deltaTime;

        // Kiểm tra khoảng cách
        if (Vector3.Distance(currentPoint.position, transform.position) < 2f)
        {
            Transform lastPoint = currentPoint;
            GetRandomPoint();

            // Đảm bảo không thêm điểm lại ngay lập tức
            if (lastPoint != currentPoint)
                points.Add(lastPoint);
        }

        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        Vector3 eulerAngles = rotation.eulerAngles;
        eulerAngles.x = 0; // Set the x component to 0
        rotation = Quaternion.Euler(eulerAngles); // Reassign the modified Euler angles back to the quaternion
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smoothSpeed);

    }

    private Transform GetRandomPoint()
    {
        currentPoint = points[Random.Range(0, points.Count)];
        points.Remove(currentPoint);
        return currentPoint;
    }
}
