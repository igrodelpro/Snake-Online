using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FoodSpawner : NetworkBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] float xSize = 8f, zSize = 8f;

    public override void OnStartServer()
    {
        ServerSpawnFood(gameObject);
        Food.ServerFoodEaten += ServerSpawnFood;
    }

    public override void OnStopServer()
    {
        Food.ServerFoodEaten -= ServerSpawnFood;
    }

    [Server]
    public void ServerSpawnFood(GameObject playerWhoAte)
    {
        Vector3 pos = new Vector3(
            Random.Range(-xSize, xSize),
            foodPrefab.transform.position.y,
            Random.Range(-zSize, zSize));
        GameObject food = Instantiate(foodPrefab, pos, foodPrefab.transform.rotation);
        NetworkServer.Spawn(food);

    }
}
//Сейчас кусочки еды для змейки появляются в разных местах в разных окнах, и они никак друг с другом не связаны.
//Механизм спавна еды находится в скрипте FoodSpawner. Измени его так, чтобы еда спавнилась во всех окнах одинаково.
//Также придется изменить скрипт самой еды: Food.
//И сделать некоторые действия в Юнити.
//Главным в этом домашнем задании является не результат, а то, чтобы ты попытался самостоятельно его достичь.
//Не бойся поломать игру, ведь благодаря версионному контролю мы сможем с легкостью откатить сделанные ошибки.