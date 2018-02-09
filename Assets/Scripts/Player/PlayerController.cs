using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : Project.NetworkBehaviour
{
    public Transform spawnLocation;
    public GameObject workerPrefab;
    public GameObject soldierPrefab;
    public GameObject archerPrefab;

    private static SpawnManager SpawnManager;

    // Use this for initialization
    void Start ()
    {
        if (SpawnManager == null)
            SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        SpawnManager.SpawnWorker += SpawnWorker;
        SpawnManager.SpawnArcher += SpawnArcher;
        SpawnManager.SpawnSoldier += SpawnSoldier;

        if (spawnLocation == null)
            spawnLocation = GameObject.Find("Spawn").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;
	}

    private void SpawnWorker(object sender, EventArgs e)
    {
        CmdSpawnWorker();
    }

    private void SpawnArcher(object sender, EventArgs e)
    {
        CmdSpawnArcher();
    }

    private void SpawnSoldier(object sender, EventArgs e)
    {
        CmdSpawnSoldier();
    }

    [Command]
    private void CmdSpawnWorker()
    {
        var go = Instantiate(workerPrefab, spawnLocation.position, Quaternion.identity);
        go.SendMessage("SetPlayer", this);
        NetworkServer.Spawn(go);
    }

    [Command]
    private void CmdSpawnArcher()
    {
        var go = Instantiate(archerPrefab, spawnLocation.position, Quaternion.identity);
        go.SendMessage("SetPlayer", this);
        NetworkServer.Spawn(go);
    }

    [Command]
    private void CmdSpawnSoldier()
    {
        var go = Instantiate(soldierPrefab, spawnLocation.position, Quaternion.identity);
        go.SendMessage("SetPlayer", this);
        NetworkServer.Spawn(go);
    }
}
