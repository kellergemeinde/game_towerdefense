﻿using System;
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

        public List<ElevatorController> Elevators;
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
        

            if(Elevators.Count == 0){
                // fill list
                for (int i = 1; i < 4; i++)
                {
                    Elevators.Add(GameObject.Find("Level/map_template/Player" + ID + "/Elevator/Elevator_0"+ i).GetComponent<GameObject>().GetComponent<ElevatorController>());
                }
            }

            // if (SpawnLocation == null)
            //     SpawnLocation = GameObject.Find("Level/Playable_Area/Player" + ID + "/Location/Spawn").transform;

            PlayerUnitsEmpty = new GameObject() { name = "Player" + ID };
            PlayerUnitsEmpty.transform.SetParent(GameObject.Find("Units").transform);

            LaneShields = new List<Transform>();
            foreach (Transform shield in GameObject.Find("Level/map_template/Player" + ID + "/Shields").transform)
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
            Transform SpawnLoc = null;
            if (e.LaneToSpawn == 1){
                
                    SpawnLoc = getSpawnLocFromElevator(1);
  
            }
            switch (e.LaneToSpawn)
            {
                case 1:
                    SpawnLoc = getSpawnLocFromElevator(1);
                    break;
                case 2:
                    SpawnLoc = getSpawnLocFromElevator(2);
                    break;
                case 3:
                    SpawnLoc = getSpawnLocFromElevator(2);
                    break;
                case 4:
                    SpawnLoc = getSpawnLocFromElevator(2);
                    break;
                case 5:
                    SpawnLoc = getSpawnLocFromElevator(3);
                    break;
                default:
                    throw new NotImplementedException();
            }


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

        private Transform getSpawnLocFromElevator(int Elevator){
            //Elevators[Elevator].idle;
            // is elev full go into holder stack
            return null;
        }
        //[Command]
        private void CmdSpawnWorker(int ID, float[] Destination)
        {
            GameObject go = (GameObject) Instantiate(workerPrefab, SpawnLocation.position, transform.rotation);
            go.transform.parent = GameObject.Find("Units/Player" + ID).transform;
            go.SendMessage("SetPlayer", ID);
            go.SendMessage("SetDestination", Destination);
            // var go = Instantiate(workerPrefab, SpawnLocation.position, Quaternion.identity);
            // go.SendMessage("SetPlayer", ID);
            // go.SendMessage("SetDestination", Destination);
            // NetworkServer.Spawn(go);
            // RpcSyncParentOnce(go, ID);
        }

        //[Command]
        private void CmdSpawnArcher(int ID, float[] Destination)
        {
            GameObject go = (GameObject) Instantiate(archerPrefab, SpawnLocation.position, transform.rotation);
            go.transform.parent = GameObject.Find("Units/Player" + ID).transform;
            go.SendMessage("SetPlayer", ID);
            go.SendMessage("SetDestination", Destination);
            // var go = Instantiate(archerPrefab, SpawnLocation.position, Quaternion.identity);
            // go.SendMessage("SetPlayer", ID);
            // go.SendMessage("SetDestination", Destination);
            // NetworkServer.Spawn(go);
            // RpcSyncParentOnce(go, ID);
        }

        //[Command]
        private void CmdSpawnSoldier(int ID, float[] Destination)
        {
            GameObject go = (GameObject) Instantiate(soldierPrefab, SpawnLocation.position, transform.rotation);
            go.transform.parent = GameObject.Find("Units/Player" + ID).transform;
            go.SendMessage("SetPlayer", ID);
            go.SendMessage("SetDestination", Destination);
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