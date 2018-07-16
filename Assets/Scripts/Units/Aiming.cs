using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Units
{
    public class Aiming : MonoBehaviour
    {
        public GameObject X { get; set; }
        public GameObject Y { get; set; }

        public float RotationSpeed { get; set; }

        public void Aim(GameObject target)
        {
            Aim(target.transform.position);
        }

        public void Aim(Vector3 target)
        {
            //Solange die forward (blaue Achse) entlang der Kanone und die Grüne parallel zum Boden verläuft
            //würde das meiner Meinung nach funktionieren.
            Vector3 direction = target - X.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);

            X.transform.rotation = Quaternion.Slerp(X.transform.rotation, rotation, RotationSpeed * Time.deltaTime);

            //Hier wenn die Forward unter der Kanone liegt und die Y nach oben
            direction.y = 0;
            rotation = Quaternion.LookRotation(direction);

            Y.transform.rotation = Quaternion.Slerp(X.transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }
    }
}
