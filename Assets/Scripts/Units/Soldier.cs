using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Units {

    public class Soldier : Entities.UnitEntity, IMoveable, IMineable
    {
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
            throw new System.NotImplementedException();
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
