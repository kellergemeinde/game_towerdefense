using UnityEngine;
using UnityEngine.AI;

namespace Project.Entities {

    public abstract class UnitEntity : Project.NetworkBehaviour, IInteractable, IFightable, IHarmable {

        public enum Behaviour {

            NEUTRAL,

            AGGRESSIVE,

            DEFENSIVE

        };

        #region PrivateFields

        private float health;

        private float attackDamage;

        private float attackSpeed;

        private float attackRange;

        [HideInInspector]
        public NavMeshAgent agent;

        #endregion

        // Use this for initialization
        public virtual void Start() {
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        public virtual void Update() { }

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

        public float AttackRange()
        {
            return attackRange;
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
