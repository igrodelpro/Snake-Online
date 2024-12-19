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
        _text.text = $"winner: {name}";
    }
    //1) Исправить баг: Когда хост нажимает кнопку выхода в меню,
    //сессия останавливается у всех клиентов, но у клиентов не скрывается UI победителя.

    //24.10
    //Земля в игре сейчас сделана при помощи плоскости (Plane). Отключи эту плоскость,
    //создай 3Д объект местности (Terrain). Нарисуй на ней текстуру QS-GRASS-8.1 (папка Assets -> Textures),
    //и нарисуй на ней траву, при помощи изображения GrassFrond01AlbedoAlpha или GrassFrond02AlbedoAlpha (также в папке Assets -> Textures).

    //редизайн GameOverDisplay
}
