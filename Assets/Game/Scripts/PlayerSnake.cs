using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Mirror;

public class PlayerSnake : NetworkBehaviour
{
    [SerializeField] TailSpawner tailSpawner;

    [Server]
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
        foreach (var t in tailSpawner.Tails)
        {
            NetworkServer.Destroy(t.gameObject);
        }
        NetworkServer.Destroy(gameObject);
        
    }
}
