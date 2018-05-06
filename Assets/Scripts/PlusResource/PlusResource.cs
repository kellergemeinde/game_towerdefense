using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project {

    public class PlusResource : Behaviour {

        //[SerializeField]
        private float amountOfPlus = 100f;

        public float AmountOfPlus { get { return amountOfPlus; } private set { amountOfPlus = value; } }

        public float Mine(float miningSpeed)
        {
            if (AmountOfPlus > miningSpeed)
            {
                AmountOfPlus -= miningSpeed;
                return miningSpeed;
            }
            else
            {
                Destroy(this, 0.1f);
                return AmountOfPlus;
            }
        }

        // Use this for initialization
        void Start() { }

        // Update is called once per frame
        void Update() { }

    }


}