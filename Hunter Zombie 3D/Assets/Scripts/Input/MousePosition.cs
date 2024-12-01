using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour, IMousePositionProvider
{
    [SerializeField] Camera main_Camera;
    [SerializeField] LayerMask layer_Mask;

    public (bool success, Vector3 position) GetMousePosition()
    {
        // a ray has starting point and direction of the ray
        var ray = main_Camera.ScreenPointToRay(Input.mousePosition);


        // return true when the ray intersects any collider, otherwise false
        if(Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, layer_Mask)) 
        {
            return (success: true, position: hitInfo.point);
        }
        else 
        {
            return (success: false, position: Vector3.zero);
        }
    }

    
}
