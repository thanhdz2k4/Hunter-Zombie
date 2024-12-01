using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    [SerializeField]
    IMousePositionProvider mousePositionProvider;

    [SerializeField] 
    Transform aimedTransform;

    [SerializeField]
    bool aim;

    [SerializeField]
    bool ignoreHeight;

    [SerializeField]
    Vector3 position1;


    private void Start()
    {
        mousePositionProvider = GetComponent<IMousePositionProvider>();
    }


    // Update is called once per frame
    void Update()
    {
        Aim(aim);
    }


    public void Aim(bool isAim)
    {
        if (aim == false)
        {
            return;
        }

        var (success, position) = mousePositionProvider.GetMousePosition();
        if (success)
        {
            // Direction is usually normalized, 
            // but it does not matter in this case.
            var direction = (position - aimedTransform.position) + position1;

            if (ignoreHeight)
            {
                // Ignore the height difference.
                direction.y = 0;
            }

            // Make the transform look at the mouse position.
            aimedTransform.forward = direction;
        }
    }

}
