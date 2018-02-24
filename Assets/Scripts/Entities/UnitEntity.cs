using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

namespace Project.Entities {

    public abstract class UnitEntity : Project.NetworkBehaviour, IInteractable, IFightable, IHarmable {

        public enum Behaviour {

            NEUTRAL,

            AGGRESSIVE,

            DEFENSIVE

        };

        #region Fields

        [HideInInspector]
        public float health;

        [HideInInspector]
        public float maxHealth;

        [HideInInspector]
        public float attackDamage;

        [HideInInspector]
        public float attackSpeed;

        [HideInInspector]
        public float attackRange;

        [HideInInspector]
        public NavMeshAgent agent;

        [HideInInspector]
        public int ID;

        #endregion

        // Use this for initialization
        public virtual void Start() {
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        public virtual void Update() { }

        public void SetPlayer(int ID)
        {
            this.ID = ID;
        }

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

        public virtual void Strike(IHarmable enemy)
        {
            throw new System.NotImplementedException();
        }

        public float CurrentHealth()
        {
            return health;
        }

        /// <summary>
        /// Taking Damage
        /// Later maybe extend with Armor or hitpoint
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="hitpoint"></param>
        public void TakeDamage(float damage, Vector3 hitpoint)
        {
            if (health <= damage)
                Die();
            else
                health -= damage;
        }

        /// <summary>
        /// Atm just destroying this Unit
        /// Later Die Animation, Time, etc.
        /// </summary>
        public void Die()
        {
            Destroy(this);
        }
    }
}
