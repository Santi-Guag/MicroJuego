using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{

    public  ObjectPool<Bullet> _pool;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        _pool = new ObjectPool<Bullet>(CreateBullet, OnTakeBulletFromPool, OnReturnBulletToPool, OnDestroyBullet, true, 10, 25);
    }

   
    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(player.bulletPrefab, player.gun.transform.position, Quaternion.identity);

        bullet.SetPool(_pool);

        return bullet;
    }

    private void OnTakeBulletFromPool(Bullet bullet)
    {
        bullet.transform.position = player.gun.transform.position;
       
        bullet.gameObject.SetActive(true);
    }

    private void OnReturnBulletToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}
