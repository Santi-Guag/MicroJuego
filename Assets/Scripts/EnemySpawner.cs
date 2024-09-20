using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Asteroid asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float xLimit;

    private float spawnNext = 0;
    private EnemyPool enemyPool;

    // Start is called before the first frame update
    void Start()
    {
        enemyPool = GetComponent<EnemyPool>();
    }
    // Update is called once per frame
    void Update()
    {

        if(Time.time > spawnNext){
            spawnNext = Time.time + 60/spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;

            enemyPool._pool.Get();
        }
        
    }
}