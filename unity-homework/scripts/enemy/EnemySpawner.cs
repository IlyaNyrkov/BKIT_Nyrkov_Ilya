using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timeForSpawn = 200;
    public float spawnAcceleration = 0;
    public GameObject enemyPrefab;
    public List<GameObject> placesToSpawn;
    private float timeForSpawnAndAcceleration;
    [SerializeField]
    private float spawnTimer = 0;
    private System.Random random;
    private void Start()
    {
        random = new System.Random();
        timeForSpawnAndAcceleration = timeForSpawn;
    }
    void FixedUpdate()
    {
        spawnTimer += Time.deltaTime;
        if (player_health.healthAmount <= 0)
        {
            timeForSpawnAndAcceleration = timeForSpawn;
        }
        if (spawnTimer >= timeForSpawnAndAcceleration && player_health.healthAmount > 0)
        {
            spawnTimer = 0;
            Instantiate(enemyPrefab, placesToSpawn[random.Next(placesToSpawn.Count)].transform);
            if (timeForSpawnAndAcceleration > 0.5f)
            {
                timeForSpawnAndAcceleration -= spawnAcceleration;
            }
        }
    }
}
