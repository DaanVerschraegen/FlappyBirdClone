using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [Header("Pool Settings")]
    [SerializeField] private int poolSize = 4;
    [SerializeField] private GameObject poolPrefab;
    [SerializeField] private Transform poolParent;
    private GameObject[] poolObjects;
    private int currentPoolObject = 0;
    private Vector2 poolSpawnPosition = new Vector2(-30f, -30f);

    [Header("Settings move spawned objects")]
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float spawnPosYMin = -1.5f;
    [SerializeField] private float spawnPosYMax = 2.5f;
    [SerializeField] private float spawnPosX = 5f;
    private float timeSinceLastMoved;

    private void Awake()
    {
        InitialisePool();

    }

    private void InitialisePool()
    {
        poolObjects = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            poolObjects[i] = (GameObject)Instantiate(poolPrefab, poolSpawnPosition, Quaternion.identity, poolParent);
        }
    }

    private void Update()
    {
        if(!GameMaster.instance.isGameOver)
        {
            timeSinceLastMoved += Time.deltaTime;

            if(timeSinceLastMoved >= spawnRate)
            {
                timeSinceLastMoved = 0;
                float randomYPosition = Random.Range(spawnPosYMin, spawnPosYMax);
                poolObjects[currentPoolObject].transform.position = new Vector2(spawnPosX, randomYPosition);
                currentPoolObject++;
                currentPoolObject %= poolSize;
            }
        }
    }
}
