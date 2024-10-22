using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    [SerializeField] TMP_Text _text;
    [SerializeField] Button _button;

    public static event Action ExitMenuClicked;

    private void OnEnable()
    {
        _canvas.enabled = false;
        GameOverHandler.RpcGameOver += DisplayWinner;
        _button.onClick.AddListener(OnExitMenuClicked);
    }

    private void OnDisable()
    {
        GameOverHandler.RpcGameOver -= DisplayWinner;
        _button.onClick.RemoveListener(OnExitMenuClicked);
    }

    private void OnExitMenuClicked()
    {
        _canvas.enabled = false;
        ExitMenuClicked?.Invoke();
    }

    private void DisplayWinner(string name)
    {
        _canvas.enabled = true;
        _text.text = name;
    }
}
