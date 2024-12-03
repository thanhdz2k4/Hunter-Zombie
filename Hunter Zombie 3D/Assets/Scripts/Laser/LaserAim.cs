using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserAim : MonoBehaviour, IAim
{
    [Header("Aim")]
    [SerializeField] private bool isAim;
    [SerializeField] private LayerMask mask;

    [Header("Laser")]
    [SerializeField] GameObject lineRenderer_Model;

    [SerializeField]
    private LineRenderer laserRenderer;
    [SerializeField] private float laserLength;
    [SerializeField] private GameObject point;
    
    private void Start() 
    {
        laserRenderer = lineRenderer_Model.GetComponent<LineRenderer>();

        if(laserRenderer == null) Debug.LogWarning("Laser renderer is null");
        point.SetActive(false);


    } 

    private void LateUpdate() {
       Aim(true);
    }

    public void Aim(bool isAim)
    {
        if(!isAim) {
            lineRenderer_Model.SetActive(false);
            point.SetActive(false);
            return;
        }

        lineRenderer_Model.SetActive(true);
        Vector3 lineEnd;

        if(Physics.Raycast(lineRenderer_Model.transform.position, lineRenderer_Model.transform.forward, out var hitPoint, laserLength, mask)) {
            lineEnd = hitPoint.point;
            point.SetActive(true);
            point.transform.position = hitPoint.point;
        }
        else {
            
            lineEnd = lineRenderer_Model.transform.position + lineRenderer_Model.transform.forward * laserLength;
        }
        laserRenderer.SetPosition(1, lineRenderer_Model.transform.InverseTransformPoint(lineEnd));
    }
}
