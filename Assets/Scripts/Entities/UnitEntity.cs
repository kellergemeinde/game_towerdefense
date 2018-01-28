using UnityEngine;

namespace Project.Entities {

    public abstract class UnitEntity : Behaviour, IInteractable, IFightable, IHarmable {

        public enum Behaviour {

            NEUTRAL,

            AGGRESSIVE,

            DEFENSIVE

        };

        #region PrivateFields

        private float health;

        private float attackDamage;

        private float attackSpeed;

        #endregion

        // Use this for initialization
        void Start() { }

        // Update is called once per frame
        void Update() { }

        public void Select()
        {
            throw new System.NotImplementedException();
        }

        public void Deselect()
        {
            throw new System.NotImplementedException();
        }

        public float AttackDamage()
        {
            return attackDamage;
        }

        public float AttackSpeed()
        {
            return attackSpeed;
        }

        public void Strike(IHarmable enemy)
        {
            throw new System.NotImplementedException();
        }

        public float Health()
        {
            return health;
        }

        public void TakeDamage(float damage, Vector3 hitpoint)
        {
            throw new System.NotImplementedException();
        }

        public void Die()
        {
            throw new System.NotImplementedException();
        }
    }

}
