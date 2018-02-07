using UnityEngine;

namespace Project.Units {

    public class Archer : Entities.MoveEntity
    {

        public Transform WhereToMove;
        public override void Start()
        {
            base.Start();

            health = 50;
            attackDamage = 20;
            attackRange = 10;
            attackSpeed = 1;

            currentRessourceAmount = 0;
            maxRessourceCapacity = 10;
            miningSpeed = 1;
            movingSpeed = 8;

            WhereToMove = GameObject.Find("Destination").transform;
            MoveTo(WhereToMove.position);
        }
    }
}
