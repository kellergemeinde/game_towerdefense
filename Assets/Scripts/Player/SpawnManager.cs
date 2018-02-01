using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SpawnManager : Project.NetworkBehaviour
{
    public Transform spawnLocation;
    public GameObject workerPrefab;
    public GameObject soldierPrefab;
    public GameObject archerPrefab;

    [Command]
    public void CmdSpawnWorker()
    {
        var go = Instantiate(workerPrefab, spawnLocation.position, Quaternion.identity);
        NetworkServer.Spawn(go);
    }

    [Command]
    public void CmdSpawnArcher()
    {
        var go = Instantiate(archerPrefab, spawnLocation.position, Quaternion.identity);
        NetworkServer.Spawn(go);
    }

    [Command]
    public void CmdSpawnSoldier()
    { 
        var go = Instantiate(soldierPrefab, spawnLocation.position, Quaternion.identity);
        NetworkServer.Spawn(go);
    }
}
