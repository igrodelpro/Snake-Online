using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameOverHandler : NetworkBehaviour
{
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

    private void OnPlayerSpawned(PlayerName playerName)
    {
        playerNames.Add(playerName);
    }

    private void OnPlayerDead(PlayerName playerName)
    {
        playerNames.Remove(playerName);
        if (playerNames.Count == 1)
        {
            print(playerNames[0].Name); 
        }
    }
}
