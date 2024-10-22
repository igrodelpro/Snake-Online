using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNetworkManager : NetworkManager
{
    [SerializeField] FoodSpawner _foodSpawnerPrefab;
    [SerializeField] GameOverHandler _gameOverHandlerPrefab;

    private void OnEnable()
    {
        GameOverDisplay.ExitMenuClicked += ExitMenu;
    }

    private void OnDisable()
    {
        GameOverDisplay.ExitMenuClicked -= ExitMenu;
    }

    private void ExitMenu()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            StopHost();
        }
        else if (NetworkServer.active)
        {
            StopServer();
        }
        else
        {
            StopClient();
        }
    }

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
