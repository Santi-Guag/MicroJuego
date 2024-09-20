using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class Asteroid : MonoBehaviour
{
    public float maxTimeLife = 2f;
    public float speed = 5f;
    public Vector3 targetVector;
    private  ObjectPool<Asteroid> _pool;

    private Coroutine deactivateAsteroidAfterTimeCoroutine;

    private void OnEnable()
    {
        deactivateAsteroidAfterTimeCoroutine = StartCoroutine(DeactivateAsteroidAfterTime());
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(targetVector * speed * Time.deltaTime);
    }


     public void SetPool(ObjectPool<Asteroid> pool)
    {
        _pool = pool;
    }

    private IEnumerator DeactivateAsteroidAfterTime()
    {
        float elapsedTime = 0f;
        while(elapsedTime < maxTimeLife)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _pool.Release(this);
    }
}
