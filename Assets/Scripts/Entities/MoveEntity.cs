using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Entities
{
    public class MoveEntity : UnitEntity, IMoveable, IMineable
    {
        public float currentRessourceAmount;

        public float maxRessourceCapacity;

        public float miningSpeed;

        public float movingSpeed;

        public override void Start()
        {
            base.Start();
        }

        public Vector3 destination;
        public void SetDestination(float[] Destination)
        {
            destination.x = Destination[0];
            destination.y = Destination[1];
            destination.z = Destination[2];
        }

        public float CurrentRessourceAmount()
        {
            return currentRessourceAmount;
        }

        public float MaxRessourceCapacity()
        {
            return maxRessourceCapacity;
        }

        public void Mine(PlusResource Resource)
        {
            currentRessourceAmount += Resource.Mine(miningSpeed);
        }

        public float MiningSpeed()
        {
            return miningSpeed;
        }

        public void MoveTo(Vector3 destination)
        {
            agent.destination = destination;
        }

        public void MoveTo(GameObject destination)
        {
            agent.destination = destination.transform.position;
        }

        public float MovingSpeed()
        {
            return movingSpeed;
        }
    }
}