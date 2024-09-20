using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Pool;


public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 2f;
    public Vector3 targetVector;

    private ObjectPool<Bullet> _pool;
    
    public EnemyPool enemyPool;


    private Coroutine deactivateBulletAfterTimeCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        enemyPool = GetComponent<EnemyPool>();

    }

    private void OnEnable()
    {
        deactivateBulletAfterTimeCoroutine = StartCoroutine(DeactivateBulletAfterTime());
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetVector * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            IncrementScore();

            _pool.Release(this);
            Asteroid asteroid = other.GetComponent<Asteroid>();
            enemyPool._pool.Release(asteroid);

        }
    }

    private void IncrementScore()
    {
        Player.SCORE++;

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos : " + Player.SCORE;
    }

    public void SetPool(ObjectPool<Bullet> pool)
    {
        _pool = pool;
    }

    private IEnumerator DeactivateBulletAfterTime()
    {
        float elapsedTime = 0f;
        while(elapsedTime < maxLifeTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _pool.Release(this);
    }
}
