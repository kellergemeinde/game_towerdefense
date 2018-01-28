using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Entities {

    public class Soldier : Entity {
        void Update()
        {
            if (!isLocalPlayer)
                return;

            var x = UnityEngine.Input.GetAxis("Horizontal") * 0.1f;
            var z = UnityEngine.Input.GetAxis("Vertical") * 0.1f;

            transform.Translate(x, 0, z);
        }
    }

}
