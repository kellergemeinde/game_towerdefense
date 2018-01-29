using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UnitSpawner : Project.NetworkBehaviour {

    public Transform spawnLocation;
    public GameObject worker;
    public GameObject soldier;
    public GameObject archer;

    [Command]
    private void CmdSpawn(GameObject gameobject)
    {
 
        var go = (GameObject)Instantiate(gameobject, spawnLocation.position, Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }

    public void SpawnSoldier()
    {
        CmdSpawn(soldier);
    }

    public void SpawnArcher()
    {
        CmdSpawn(archer);
    }

    public void SpawnWorker()
    {
        CmdSpawn(worker);
    }
}
