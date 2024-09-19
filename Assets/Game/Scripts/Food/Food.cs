using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Food : NetworkBehaviour
{
    [SerializeField] GameObject particlePrefab;
    [SerializeField] Renderer renderer;

    private bool _isActive = true;

    public static event System.Action ServerFoodEaten;

    [ServerCallback]
    void OnTriggerEnter(Collider other)
    {
        if (!_isActive || !other.CompareTag("Player")) return;

        _isActive = false;
        GameObject boom = Instantiate
            (particlePrefab, transform.position, particlePrefab.transform.rotation);
        NetworkServer.Spawn(boom);
        RpcOnFoodEaten();
        ServerFoodEaten?.Invoke();
        StartCoroutine(DestroyBoomDelay(boom, 3f));
    }

    [ClientRpc]
    private void RpcOnFoodEaten()
    {
        renderer.enabled = false;
    }

    private IEnumerator DestroyBoomDelay(GameObject boom, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        NetworkServer.Destroy(boom);
        NetworkServer.Destroy(gameObject);
    }
}
