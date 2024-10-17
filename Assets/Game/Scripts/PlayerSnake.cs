using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSnake : NetworkBehaviour
{
    [SerializeField] TailSpawner tailSpawner;
    [SerializeField] PlayerName playerName;

    static public event Action<PlayerName> ServerPlayerSpawned;
    static public event Action<PlayerName> ServerPlayerDespawned;

    public override void OnStartServer()
    {
        ServerPlayerSpawned?.Invoke(playerName);
    }

    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Border":
            case "Player":
            case "Tail":
                if (tailSpawner.Tails.Contains(other.GetComponent<TailNetwork>()))
                    break;
                DestroySelf();
                break;
            
        }
    }

    [Server]
    private void DestroySelf()
    {
        ServerPlayerDespawned?.Invoke(playerName);
        foreach (var t in tailSpawner.Tails)
        {
            NetworkServer.Destroy(t.gameObject);
        }
        NetworkServer.Destroy(gameObject);
        
    }
}
