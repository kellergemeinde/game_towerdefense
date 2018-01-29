using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUI : MonoBehaviour {

    public UnitSpawner unitSpawner;


	public void SpawnWorker()
    {
        unitSpawner.SpawnWorker();
    }

    public void SpawnSoldier()
    {
        unitSpawner.SpawnSoldier();
    }

    public void SpawnArcher()
    {
        unitSpawner.SpawnArcher();
    }
}
