using System.Collections;
using UnityEngine;

namespace Utils
{
    public class PrefabSpawner : MonoBehaviour
    {
        public string ShipAreaTag = "ShipArea";
        public float SpawnDelay;
            
        public GameObject Prefab;

        void Start()
        {
            StartCoroutine(SpawnLoop());
        }

        IEnumerator SpawnLoop()
        {
            while (true)
            {
                var shipTransform = GameObject.FindWithTag(ShipAreaTag).transform;
                print(shipTransform);
                var spawnLocation = new Vector3(
                    shipTransform.position.x + Random.Range(15f, 200f),
                    shipTransform.position.y + Random.Range(15f, 200f),
                    shipTransform.position.z
                );

                Instantiate(Prefab, spawnLocation, Quaternion.identity);
                yield return new WaitForSeconds(SpawnDelay);
            }
        }
    }
}