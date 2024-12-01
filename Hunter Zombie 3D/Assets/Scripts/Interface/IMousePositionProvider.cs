using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMousePositionProvider 
{
    (bool success, Vector3 position) GetMousePosition();
}
