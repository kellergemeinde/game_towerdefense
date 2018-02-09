using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class PlayerController : Project.NetworkBehaviour
{
    public static int MaxID { get; private set; }

    [SerializeField]
    public float[] Destination;

    public Transform SpawnLocation;
    public GameObject workerPrefab;
    public GameObject soldierPrefab;
    public GameObject archerPrefab;

    public int ID { get; private set; }
    private GameObject PlayerUnitsEmpty;

    private static SpawnManager SpawnManager;

    private List<Transform> LaneShields;

    // Use this for initialization
    void Start ()
    {
        MaxID++;
        ID = MaxID;

        if (SpawnManager == null)
            SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        SpawnManager.SpawnUnit += SpawnUnit;

        if (SpawnLocation == null)
            SpawnLocation = GameObject.Find("Level/Player" + ID + "/Location/Spawn").transform;

        PlayerUnitsEmpty = new GameObject() { name = "Player" + ID };
        PlayerUnitsEmpty.transform.parent = GameObject.Find("Units").transform;

        LaneShields = new List<Transform>();
        foreach (Transform shield in GameObject.Find("Level/Player" + ID + "/Shields").transform)
        {
            LaneShields.Add(shield.transform);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;
	}

    private void SpawnUnit(SpawnManager.SpawnEventArgs e)
    {
        if (!isLocalPlayer)
            return;

        Destination = new float[] { LaneShields[e.LaneToSpawn - 1].position.x + 0.5f, LaneShields[e.LaneToSpawn - 1].position.y, LaneShields[e.LaneToSpawn - 1].position.z };

        switch (e.UnitToSpawn)
        {
            case SpawnManager.SpawnEventArgs.Unit.Worker:
                CmdSpawnWorker(Destination);
                break;
            case SpawnManager.SpawnEventArgs.Unit.Archer:
                CmdSpawnArcher(Destination);
                break;
            case SpawnManager.SpawnEventArgs.Unit.Soldier:
                CmdSpawnSoldier(Destination);
                break;
            default:
                throw new NotImplementedException();
                //break;
        }
    }

    [Command]
    private void CmdSpawnWorker(float[] Destination)
    {
        var go = Instantiate(workerPrefab, SpawnLocation.position, Quaternion.identity, PlayerUnitsEmpty.transform);
        go.SendMessage("SetPlayer", this);
        go.SendMessage("SetDestination", Destination);
        NetworkServer.Spawn(go);
    }

    [Command]
    private void CmdSpawnArcher(float[] Destination)
    {
        var go = Instantiate(archerPrefab, SpawnLocation.position, Quaternion.identity, PlayerUnitsEmpty.transform);
        go.SendMessage("SetPlayer", this);
        go.SendMessage("SetDestination", Destination);
        NetworkServer.Spawn(go);
    }

    [Command]
    private void CmdSpawnSoldier(float[] Destination)
    {
        var go = Instantiate(soldierPrefab, SpawnLocation.position, Quaternion.identity, PlayerUnitsEmpty.transform);
        go.SendMessage("SetPlayer", this);
        go.SendMessage("SetDestination", Destination);
        NetworkServer.Spawn(go);
    }
}
