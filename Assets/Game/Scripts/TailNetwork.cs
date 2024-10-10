using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TailNetwork : NetworkBehaviour
{
    [SerializeField, SyncVar] private Transform _target;
    [SerializeField, SyncVar] private SnakeNetwork _owner;

    [Server]
    public void InitServer(Transform target, SnakeNetwork owner)
    {
        _owner = owner;
        _target = target;
    }

    [Client]
    public void UpdateDestination()
    {
        if (!isOwned) return;

        float distance = _target.localScale.z * 0.5f;
        Vector3 direction = (_target.position - transform.position).normalized;
        Vector3 newPos = _target.position - direction * distance;
        transform.position = newPos;
    }

    //1) Реализовать движение хвостов, так как мы реализовали в оригинальном проекте в одиночном режиме игры;

    //2) В игре "Шахматы" спроектировать уникальные методы движения каждого существа, олицетворяемого фигурами
}
