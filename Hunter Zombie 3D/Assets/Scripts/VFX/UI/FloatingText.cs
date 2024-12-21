using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] float timerKill;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timerKill);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
