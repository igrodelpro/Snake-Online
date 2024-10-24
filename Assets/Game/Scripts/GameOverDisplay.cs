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

    private void OnExitMenuClicked()
    {
        ExitMenuClicked?.Invoke();
    }

    public void SetActive(bool value)
    {
        _canvas.enabled = value;
        if (value)
        {
            GameOverHandler.RpcGameOver -= DisplayWinner;
            _button.onClick.AddListener(OnExitMenuClicked);
        }
        else
        {
            GameOverHandler.RpcGameOver += DisplayWinner;
            _button.onClick.RemoveListener(OnExitMenuClicked);
        }
    }

    private void DisplayWinner(string name)
    {
        SetActive(true);
        _text.text = name;
    }
    //1) »справить баг:  огда хост нажимает кнопку выхода в меню,
    //сесси€ останавливаетс€ у всех клиентов, но у клиентов не скрываетс€ UI победител€.
}
