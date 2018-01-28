using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float ObjectTtl;

    private float _spawnTime;

    private void Start()
    {
        _spawnTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= _spawnTime + ObjectTtl)
        {
            Destroy(gameObject);
        }
    }
}