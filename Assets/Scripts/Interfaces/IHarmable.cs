namespace Project {

    public interface IHarmable {

        /// <summary>
        /// Change the target enemy and harm them with Strike.
        /// </summary>
        void Attack();

        void Strike(IFightable enemy);

        float Damage();

        float Speed();

    }

}
