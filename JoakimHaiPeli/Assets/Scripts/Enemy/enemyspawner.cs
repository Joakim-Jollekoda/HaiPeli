using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    public float spawnInterval =2f;

    private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }
    void SpawnEnemy()
    {
       GameObject enemy = EnemyPoolManager.Instance.GetEnemy();
       enemy.transform.position = transform.position; 
    }
}