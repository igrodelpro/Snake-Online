using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class PlayerName : NetworkBehaviour
{
    [SerializeField] TMP_Text _nameText;

    [SyncVar(hook = "UpdateNameText")] private string _name;

    public string Name { get { return _name; } }

    public override void OnStartServer()
    {
        _name = $"Player {connectionToClient.connectionId}";
    }
    private void UpdateNameText(string oldValue, string newValue)
    {
        _nameText.text = newValue;
    }
}
