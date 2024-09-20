using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class EnemyPool : MonoBehaviour
{

    public  ObjectPool<Asteroid> _pool;
    private EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GetComponent<EnemySpawner>();
        _pool = new ObjectPool<Asteroid>(CreateAsteroid, OnTakeAsteroidFromPool, OnReturnAsteroidToPool, OnDestroyAsteroid, true, 10, 25);
    }

     private Asteroid CreateAsteroid()
    {
        float rand = Random.Range(-enemySpawner.xLimit, enemySpawner.xLimit);
        Vector2 spawnPosition = new Vector2(rand, 8f);
        Asteroid asteroid = Instantiate(enemySpawner.asteroidPrefab, spawnPosition, Quaternion.identity);

        asteroid.SetPool(_pool);

        return asteroid;
    }

    private void OnTakeAsteroidFromPool(Asteroid asteroid)
    {
        float rand = Random.Range(-enemySpawner.xLimit, enemySpawner.xLimit);
        Vector2 spawnPosition = new Vector2(rand, 8f);
        asteroid.transform.position = spawnPosition;
       
        asteroid.gameObject.SetActive(true);
    }

    private void OnReturnAsteroidToPool(Asteroid asteroid)
    {
        asteroid.gameObject.SetActive(false);
    }

    private void OnDestroyAsteroid(Asteroid asteroid)
    {
        Destroy(asteroid);
    }

}
