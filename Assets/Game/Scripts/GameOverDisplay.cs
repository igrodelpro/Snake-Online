using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    [SerializeField] TMP_Text _text;

    private void OnEnable()
    {
        _canvas.enabled = false;
        GameOverHandler.RpcGameOver += DisplayWinner;
    }

    private void OnDisable()
    {
        GameOverHandler.RpcGameOver -= DisplayWinner;
    }

    private void DisplayWinner(string name)
    {
        _canvas.enabled = true;
        _text.text = name;
    }
}
