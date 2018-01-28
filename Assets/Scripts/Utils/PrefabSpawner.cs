using System.Collections;
using UnityEngine;

namespace Utils
{
    public class PrefabSpawner : MonoBehaviour
    {
        public string ShipAreaTag = "ShipArea";
        public float SpawnDelay;
            
        public GameObject Prefab;

        [SerializeField]
        GameObject shipObject;

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
                    Random.Range(50, 200f) + shipObject.transform.position.x,
                    shipTransform.position.y + Random.Range(-70f, 70f),    
                    shipTransform.position.z
                );

                if (LayerMask.LayerToName(Prefab.layer) == "OnlyPlayer")
                {
                    Instantiate(Prefab, spawnLocation, Quaternion.Euler(-90,180,90));
                }
                else
                {
                    Instantiate(Prefab, spawnLocation, Quaternion.Euler(-90,0,0));
                }           
                yield return new WaitForSeconds(SpawnDelay);
            }
        }
    }
}