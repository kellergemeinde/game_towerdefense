
namespace Project.Units {

    public class Worker : Entities.MoveEntity
    {
        public override void Start()
        {
            base.Start();

            health = 30;
            attackDamage = 10;
            attackRange = 1;
            attackSpeed = 2;

            currentRessourceAmount = 0;
            maxRessourceCapacity = 100;
            miningSpeed = 2;
            movingSpeed = 10;

            MoveTo(destination);
        }
    }
}
