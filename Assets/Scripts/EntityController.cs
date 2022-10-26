using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public GameObject collectable;
    private float spawnRangeX = 19;
    private float spawnRangeZ = 19;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnCollectable", startDelay, spawnInterval);
    }
    void SpawnCollectable()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.5f, Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(collectable, spawnPos, collectable.transform.rotation);
    }
}
