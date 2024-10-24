using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class GameOverHandler : NetworkBehaviour
{
    private List<PlayerName> playerNames = new List<PlayerName>();

    public static event Action<string> RpcGameOver;

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
        RpcGameOver?.Invoke(winner);
    }
}
