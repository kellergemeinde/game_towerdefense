using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Project
{
    //[Serializable]
    public class PlayerController : Project.NetworkBehaviour
    {
        public static int MaxID { get; private set; }

        //[SerializeField]
        public float[] Destination;

        //[SerializeField]
        public int ID { get; private set; }

        public Transform SpawnLocation;
        public GameObject workerPrefab;
        public GameObject soldierPrefab;
        public GameObject archerPrefab;

        private GameObject PlayerUnitsEmpty;

        private static SpawnManager SpawnManager;

        private List<Transform> LaneShields;

        // Use this for initialization
        void Start()
        {
            MaxID++;
            ID = MaxID;

            transform.gameObject.name = "Player" + ID;

            if (SpawnManager == null)
                SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            SpawnManager.SpawnUnit += SpawnUnit;

            if (SpawnLocation == null)
                SpawnLocation = GameObject.Find("Level/Playable_Area/Player" + ID + "/Location/Spawn").transform;

            PlayerUnitsEmpty = new GameObject() { name = "Player" + ID };
            PlayerUnitsEmpty.transform.SetParent(GameObject.Find("Units").transform);

            LaneShields = new List<Transform>();
            foreach (Transform shield in GameObject.Find("Level/Playable_Area/Player" + ID + "/Shields").transform)
            {
                LaneShields.Add(shield.transform);
            }
        }

        // Update is called once per frame
        void Update()
        {
            //if (!isLocalPlayer)
                //return;
        }

        private void SpawnUnit(SpawnManager.SpawnEventArgs e)
        {
            //if (!isLocalPlayer)
                //return;

            Destination = new float[] { LaneShields[e.LaneToSpawn - 1].position.x + 0.5f, LaneShields[e.LaneToSpawn - 1].position.y, LaneShields[e.LaneToSpawn - 1].position.z };

            switch (e.UnitToSpawn)
            {
                case SpawnManager.SpawnEventArgs.Unit.Worker:
                    CmdSpawnWorker(this.ID, Destination);
                    break;
                case SpawnManager.SpawnEventArgs.Unit.Archer:
                    CmdSpawnArcher(this.ID, Destination);
                    break;
                case SpawnManager.SpawnEventArgs.Unit.Soldier:
                    CmdSpawnSoldier(this.ID, Destination);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        //[Command]
        private void CmdSpawnWorker(int ID, float[] Destination)
        {
            GameObject worker = (GameObject) Instantiate(workerPrefab, SpawnLocation.position, transform.rotation);
            worker.transform.parent = GameObject.Find("Units/Player" + ID).transform;
            // var go = Instantiate(workerPrefab, SpawnLocation.position, Quaternion.identity);
            // go.SendMessage("SetPlayer", ID);
            // go.SendMessage("SetDestination", Destination);
            // NetworkServer.Spawn(go);
            // RpcSyncParentOnce(go, ID);
        }

        //[Command]
        private void CmdSpawnArcher(int ID, float[] Destination)
        {
            GameObject worker = (GameObject) Instantiate(archerPrefab, SpawnLocation.position, transform.rotation);
            worker.transform.parent = GameObject.Find("Units/Player" + ID).transform;
            // var go = Instantiate(archerPrefab, SpawnLocation.position, Quaternion.identity);
            // go.SendMessage("SetPlayer", ID);
            // go.SendMessage("SetDestination", Destination);
            // NetworkServer.Spawn(go);
            // RpcSyncParentOnce(go, ID);
        }

        //[Command]
        private void CmdSpawnSoldier(int ID, float[] Destination)
        {
            GameObject worker = (GameObject) Instantiate(soldierPrefab, SpawnLocation.position, transform.rotation);
            worker.transform.parent = GameObject.Find("Units/Player" + ID).transform;
            // var go = Instantiate(soldierPrefab, SpawnLocation.position, Quaternion.identity);
            // go.SendMessage("SetPlayer", ID);
            // go.SendMessage("SetDestination", Destination);
            // NetworkServer.Spawn(go);
            // RpcSyncParentOnce(go, ID);
        }

        //[ClientRpc]
        private void RpcSyncParentOnce(GameObject go, int ID)
        {
            go.transform.parent = GameObject.Find("Units/Player" + ID).transform;
        }
    }
}