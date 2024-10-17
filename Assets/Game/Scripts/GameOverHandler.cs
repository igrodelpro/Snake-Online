using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Unity.VisualScripting;

public class GameOverHandler : NetworkBehaviour
{
    [SerializeField] GameOverDisplay _displayPrefab;
    
    private GameOverDisplay _display;

    private List<PlayerName> playerNames = new List<PlayerName>();


    public override void OnStartServer()
    {
        PlayerSnake.ServerPlayerSpawned += OnPlayerSpawned;
        PlayerSnake.ServerPlayerDespawned += OnPlayerDead;
    }



    public override void OnStopServer()
    {
        PlayerSnake.ServerPlayerSpawned -= OnPlayerSpawned;
        PlayerSnake.ServerPlayerDespawned -= OnPlayerDead;
    }

    public override void OnStartClient()
    {
        _display = Instantiate(_displayPrefab);
    }

    public override void OnStopClient()
    {
        Destroy(_display.gameObject); 
    }


    [Server]
    private void OnPlayerSpawned(PlayerName playerName)
    {
        playerNames.Add(playerName);
    }

    [Server]
    private void OnPlayerDead(PlayerName playerName)
    {
        playerNames.Remove(playerName);
        if (playerNames.Count == 1)
        {
            RpcDisplayWinner(playerNames[0].Name);
        }
    }

    [ClientRpc]
    private void RpcDisplayWinner(string winner)
    {
        _display.SetWinner(winner);
        _display.SetActive(true);
    }
}
