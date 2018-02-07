using UnityEngine;

namespace Project.Units {

    public class Archer : Entities.UnitEntity, IMoveable, IMineable
    {
        public Transform WhereToMove;
        public override void Start()
        {
            base.Start();
            WhereToMove = GameObject.Find("Destination").transform;
            MoveTo(WhereToMove.position);
        }

        public float CurrentRessourceAmount()
        {
            throw new System.NotImplementedException();
        }

        public float MaxRessourceCapacity()
        {
            throw new System.NotImplementedException();
        }

        public void Mine()
        {
            throw new System.NotImplementedException();
        }

        public float MiningSpeed()
        {
            throw new System.NotImplementedException();
        }

        public void MoveTo(Vector3 destination)
        {
            agent.destination = destination;
        }

        public void MoveTo(GameObject destination)
        {
            throw new System.NotImplementedException();
        }

        public float MovingSpeed()
        {
            throw new System.NotImplementedException();
        }
    }

}
