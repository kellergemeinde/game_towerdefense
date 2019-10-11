using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    public GameObject ElevatorPrefab;
    public bool idle;
    public float doorSpeed = 1;
    public float elevatorSpeed = 2;
    public float doorsize = 2.6f; // TODO get Z heigh from gameobject
    public GameObject ElevatorDoor;
    public List<GameObject> spawn;
    private bool boolMoveDoor;
    private int doorDirection;
    private int unitsIn;
    private Vector3 doorEndPos;
    private Vector3 elevPos;
    // Start is called before the first frame update
    void Start()
    {
        //set the elevator to ready state
        idle = true;
        boolMoveDoor = true;       
        doorSpeed = doorSpeed * Time.deltaTime;
        elevatorSpeed = elevatorSpeed * Time.deltaTime;
        // get spawn points 
        for (int i = 0; i < 4; i++)
        {
            spawn.Add(this.GetComponentInChildren(); //TODO finish
        }
        openDoor();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(!this.idle){
            //to moving stuff
            this.transform.position = Vector3.Lerp(this.transform.position, elevPos, this.elevatorSpeed);
            if(this.transform.position == elevPos){
                enableIdle();
            }
        }

        if (boolMoveDoor && this.idle){
            ElevatorDoor.transform.localPosition = Vector3.Lerp(ElevatorDoor.transform.localPosition, doorEndPos, this.doorSpeed);
            if(ElevatorDoor.transform.localPosition == doorEndPos){
                    boolMoveDoor = false; // allow units to move
            }
        }//TODO set boolMoveDoor to finish
	}
    void enableIdle(){
        this.idle = true;
    }
    void moveDown(){
        elevPos = new Vector3(transform.position.x,transform.position.y,transform.position.z + 10);
        this.idle = false;
    }
    void moveUp(){
        elevPos = new Vector3(transform.position.x,transform.position.y,transform.position.z - 10);
        this.idle = false;
    }
    // Call then all units out with invisble collider count the units down
    void closeDoor(){
        doorEndPos = new Vector3(ElevatorDoor.transform.localPosition.x,ElevatorDoor.transform.localPosition.y,ElevatorDoor.transform.localPosition.z + doorsize );
    }
    void openDoor(){
        doorEndPos = new Vector3(ElevatorDoor.transform.localPosition.x,ElevatorDoor.transform.localPosition.y,ElevatorDoor.transform.localPosition.z - doorsize );
    }
}
