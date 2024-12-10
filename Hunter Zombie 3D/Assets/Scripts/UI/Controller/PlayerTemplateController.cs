using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTemplateController : MonoBehaviour
{
    public static event Action<List<PlayerSO>> fillPlayersEvent;

    [SerializeField] List<PlayerSO> players = new List<PlayerSO>();

    private void Start()
    {
        fillPlayersEvent?.Invoke(players);
    }

    
}
