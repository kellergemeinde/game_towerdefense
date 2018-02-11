
namespace Project.Units {

    public class Soldier : Entities.MoveEntity
    {
        public override void Start()
        {
            base.Start();

            health = 120;
            attackDamage = 30;
            attackRange = 1;
            attackSpeed = 1.5f;

            currentRessourceAmount = 0;
            maxRessourceCapacity = 25;
            miningSpeed = 1.5f;
            movingSpeed = 5;
            
            MoveTo(destination);
        }
    }
}
