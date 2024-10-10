using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class SnakeNetwork : NetworkBehaviour
{
    [SerializeField] float speed = 3f, rotationSpeed = 180f, speedChange = 0.5f;
    [SerializeField] TailSpawner _tailSpawner;

    public float Speed { get { return speed; } private set { speed = value; } }

    public override void OnStartServer()
    {
        Food.ServerFoodEaten += IncreaseSpeed;
    }

    public override void OnStopServer()
    {
        Food.ServerFoodEaten -= IncreaseSpeed;
    }

    [ClientRpc]
    private void IncreaseSpeed(GameObject playerWhoAte)
    {
        if (playerWhoAte != gameObject) return;
        Speed += speedChange;
    }

    [Client]
    void Update()
    {
        if (!isOwned) return;

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));

        foreach (TailNetwork tail in _tailSpawner.Tails)
        {
            tail.UpdateDestination();
        }
    }
}
