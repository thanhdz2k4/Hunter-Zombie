using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAWSD : MonoBehaviour, IInput
{
    public Vector2 Data()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    
}
