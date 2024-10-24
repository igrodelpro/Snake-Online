using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNetworkManager : NetworkManager
{
    [SerializeField] FoodSpawner _foodSpawnerPrefab;
    [SerializeField] GameOverHandler _gameOverHandlerPrefab;
    [SerializeField] GameOverDisplay _gameOverDisplay;

    private void OnEnable()
    {
        GameOverDisplay.ExitMenuClicked += ExitMenu;
    }

    private void OnDisable()
    {
        GameOverDisplay.ExitMenuClicked -= ExitMenu;
    }

    public override void OnStartClient()
    {
        _gameOverDisplay.SetActive(false);
    }

    private void ExitMenu()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            StopHost();
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

    public override void OnStopHost()
    {
        _gameOverDisplay.SetActive(false);
    }

    public override void OnStopClient()
    {
        _gameOverDisplay.SetActive(false);
    }
}
