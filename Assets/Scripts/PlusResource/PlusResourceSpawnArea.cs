using UnityEngine;

namespace Project.Entities
{
    public class PlusResourceSpawnArea : NetworkBehaviour
    {
        //[SerializeField]
        private int amountOfPlusAtTheBeginning;

        //[SerializeField]
        private GameObject plusSpawnArea;

        //[SerializeField]
        private GameObject plusResourcePrefab;

        private RangeAttribute minMaxX;
        private RangeAttribute minMaxY;
        private RangeAttribute minMaxZ;

        /// <summary>
        /// Spawn the plus resource at the beginning of the game.
        /// </summary>
        void Start()
        {
            Vector3 center = plusSpawnArea.transform.position;
            Vector3 extents = plusSpawnArea.transform.localScale / 2;
            minMaxY = new RangeAttribute(center.y - extents.y, center.y + extents.y);
            minMaxZ = new RangeAttribute(center.z - extents.z, center.z + extents.z);

            for (int i = 0; i < amountOfPlusAtTheBeginning; i++)
            {
                Instantiate(plusResourcePrefab, new Vector3(
                    center.x, Random.Range(minMaxY.min, minMaxY.max), Random.Range(minMaxZ.min, minMaxZ.max)), 
                    Quaternion.identity,
                    GameObject.Find("Ressource").transform);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
