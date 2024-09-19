using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNetworkManager : NetworkManager
{
    [SerializeField] FoodSpawner _foodSpawnerPrefab;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        if (numPlayers != 2) return;

        FoodSpawner foodSpawner = Instantiate(_foodSpawnerPrefab);
        NetworkServer.Spawn(foodSpawner.gameObject);
    }
}
