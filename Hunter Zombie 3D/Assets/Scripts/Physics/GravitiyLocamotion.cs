using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitiyLocamotion : MonoBehaviour, IGravityLocamotion
{
    [SerializeField] float gravity = -9.81f;

    private float verticalVelocity;
    public float Gravity(bool isGround)
    {
        if(isGround) 
        {
            if(verticalVelocity < 0 ) verticalVelocity = -2f;

        } else verticalVelocity += gravity * Time.deltaTime;

        return verticalVelocity;
    }

    
}
