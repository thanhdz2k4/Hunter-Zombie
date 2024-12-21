using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Transform player;

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.forward);
        Vector3 eulerAngles = rotation.eulerAngles;
        rotation = Quaternion.Euler(eulerAngles);

        transform.rotation = rotation;
    }
}
