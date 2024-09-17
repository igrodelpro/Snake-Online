using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCameraController : NetworkBehaviour
{
    [SerializeField] GameObject _cam;

    public override void OnStartAuthority()
    {
        _cam.SetActive(true);
    }
    //1. Продолжить шахматы
    //2. Создай репозиторий для проекта мультиплеерного пинг-понга.

    //Пошагово:
    //- создать пустую репозиторию на сайте GitHub;
    //- склонировать репозиторию на свой компьютер с помощью Sourcetree;
    //- скопировать содержимое проекта мультиплеерного пинг-понга в папку репозитория;
    //- сделать коммит и отправить его в GitHub.
}
