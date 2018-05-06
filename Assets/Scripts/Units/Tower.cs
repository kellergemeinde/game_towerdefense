using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Units {

    public class Tower : Entities.UnitEntity
    {
        public override void Start()
        {
            base.Start();

            maxHealth = 100;
            health = 100;
        }
    }

}