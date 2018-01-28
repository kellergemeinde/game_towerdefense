namespace Project
{

    public interface IFightable
    {

        float AttackDamage();

        float AttackSpeed();

        float AttackRange();

        void Strike(IHarmable enemy);

    }

}