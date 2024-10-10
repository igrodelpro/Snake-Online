using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TailSpawner : NetworkBehaviour
{
    [SerializeField] TailNetwork tailPrefab;

    public SyncList<TailNetwork> Tails { get; } = new SyncList<TailNetwork>();

    public override void OnStartServer()
    {
        Food.ServerFoodEaten += AddTail;
    }

    public override void OnStopServer()
    {
        Food.ServerFoodEaten -= AddTail;
    }

    [Server]
    public void AddTail(GameObject playerWhoAte)
    {
        if (playerWhoAte != gameObject) return;

        Transform target = Tails.Count == 0 ? transform : Tails[Tails.Count - 1].transform;

        TailNetwork tail = Instantiate(tailPrefab, target.position, Quaternion.identity);
        tail.InitServer(target, GetComponent<SnakeNetwork>());
        NetworkServer.Spawn(tail.gameObject, connectionToClient);

        Tails.Add(tail);
    }
}
