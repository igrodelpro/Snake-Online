using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNetworkManager : NetworkManager
{
    [SerializeField] FoodSpawner _foodSpawnerPrefab;
    [SerializeField] GameOverHandler _gameOverHandlerPrefab;

    public override void OnStartServer()
    {
        GameOverHandler gameOverHandler = Instantiate(_gameOverHandlerPrefab);
        NetworkServer.Spawn(gameOverHandler.gameObject);
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        if (numPlayers != 2) return;

        FoodSpawner foodSpawner = Instantiate(_foodSpawnerPrefab);
        NetworkServer.Spawn(foodSpawner.gameObject);
    }
}
