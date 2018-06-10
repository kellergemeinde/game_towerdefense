using UnityEngine;
using System.Collections;

namespace Project.Entities
{
    public class PlusResourceSpawnArea : Behaviour
    {
        public GameObject plusResourcePrefab;
        //[SerializeField]
        private int amountOfPlusAtTheBeginning;

        //[SerializeField]
        private GameObject plusSpawnArea;

        /// <summary>
        /// Spawn the plus resource at the beginning of the game.
        /// </summary>
        void Start()
        {
            plusSpawnArea = this.gameObject;
            StartCoroutine(spawnResource());
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        //TODO add resource spawn event
        IEnumerator spawnResource()
        {
            yield return new WaitForSeconds(5);
            GameObject resource = Instantiate(plusResourcePrefab, new Vector3(plusSpawnArea.transform.position.x, plusSpawnArea.transform.position.y, plusSpawnArea.transform.position.z), Quaternion.identity);
            resource.transform.SetParent(plusSpawnArea.transform);
            resource.GetComponent<Rigidbody>().AddForce(plusSpawnArea.transform.up * 4, ForceMode.Impulse);
        }
    }
}
