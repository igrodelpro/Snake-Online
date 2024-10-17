using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using Org.BouncyCastle.Security;

public class GameOverDisplay : NetworkBehaviour
{
    [SerializeField] Canvas _canvas;
    [SerializeField] TMP_Text _winnerText;
    [SerializeField] Button _restartButton;

    [Client]
    private void Start()
    {
        SetActive(false);
    }


    public void SetActive(bool value)
    {
        _canvas.enabled = value;

        if (value)
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }
        else
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }
    }

    public void SetWinner(string winner)
    {
        _winnerText.text = $"{winner} winner";
    }

    [Client]
    private void OnRestartButtonClicked()
    {
        SetActive(false);
        CmdStopHostRequest();
    }

    [Command]
    private void CmdStopHostRequest()
    {
        if (NetworkClient.active)
            NetworkManager.singleton.StopHost();
        else
            NetworkManager.singleton.StopServer();
    }

}
