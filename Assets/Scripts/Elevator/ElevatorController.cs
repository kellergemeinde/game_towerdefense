using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    public GameObject ElevatorPrefab;
    public bool idle;
    public float doorSpeed;
    public float elevatorSpeed;
    public int doorsize = 50; // TODO get Z heigh from gameobject
    private GameObject ElevatorDoor;
    private bool boolMoveDoor;
    private int doorDirection;
    private float lastDoorPosZ;
    private int unitsIn;
    // Start is called before the first frame update
    void Start()
    {
        // Grap Elevator door
        ElevatorDoor = GetComponentInChildren<GameObject>();
        //set the elevator to ready state
        idle = false;
        doorSpeed = doorSpeed * Time.deltaTime;
        elevatorSpeed = elevatorSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(!this.idle){
            //to moving stuff

            this.transform.position = Vector3.MoveTowards(ElevatorDoor.transform.position, new Vector3(transform.position.x,transform.position.y,transform.position.z + 100), this.doorSpeed);
        }

        if (boolMoveDoor){


            ElevatorDoor.transform.position = Vector3.MoveTowards(ElevatorDoor.transform.position, new Vector3(ElevatorDoor.transform.position.x,ElevatorDoor.transform.position.y,ElevatorDoor.transform.position.z +  doorsize), this.doorSpeed);
            
            if(doorDirection == 1 && ElevatorDoor.transform.position.z <= ElevatorDoor.transform.position.z + doorsize){
                    boolMoveDoor = false; // allow units to move
            }else if(doorDirection == -1 && ElevatorDoor.transform.position.z >= ElevatorDoor.transform.position.z + doorsize){

            }

        }else{
            return;
        }
	}
    void enableIdle(){
        this.idle = true;
        this.lastDoorPosZ = ElevatorDoor.transform.position.z;
        this.doorDirection = 1;
    }
    void disableIdle(){
        this.idle = false;
    }
    // Call then all units out with invisble collider count the units down
    void closeDoor(){
        this.doorDirection = -1;
    }
}
