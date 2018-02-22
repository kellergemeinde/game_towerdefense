using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Entities
{
    public class UnitHealth : MonoBehaviour
    {

        public RectTransform Healthbar;

        private UnitEntity EntityWithHealth;

        // Use this for initialization
        void Start()
        {
            EntityWithHealth = gameObject.GetComponent<UnitEntity>();
        }

        // Update is called once per frame
        void Update()
        {
            // Update the healtbar rotation
            /*
            transform.eulerAngles = new Vector3(
                Camera.main.transform.eulerAngles.x,
                Camera.main.transform.parent.gameObject.transform.eulerAngles.y,
                transform.eulerAngles.z
                );
                */

            // Update health bar
            float healthInProcent = EntityWithHealth.health / EntityWithHealth.maxHealth;
            Healthbar.transform.localScale = new Vector3(healthInProcent, 1, 1);
        }
    }
}
