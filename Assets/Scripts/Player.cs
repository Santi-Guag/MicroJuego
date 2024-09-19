using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float thrustForce = 100f;
    public float rotationSpeed = 120f;

    public GameObject gun;
    public Bullet bulletPrefab;

    public static int SCORE = 0;
    public static float xBorderLimit, yBorderLimit;

    private Rigidbody _rigid;
    private BulletSpawner bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();

        xBorderLimit = (Camera.main.orthographicSize+1) * Screen.width / Screen.height;
        yBorderLimit = Camera.main.orthographicSize+1;

        bulletSpawner = GetComponent<BulletSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = transform.position;
        if(newPos.x > xBorderLimit)
        {
            newPos.x = -xBorderLimit+1;
        }
        else if(newPos.x < -xBorderLimit)
        {
            newPos.x = xBorderLimit-1;
        }
        else if (newPos.y > yBorderLimit)
        {
            newPos.y = -yBorderLimit+1;
        }
        else if (newPos.y < -yBorderLimit)
        {
            newPos.y = yBorderLimit-1;
        }
        transform.position = newPos;


        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;
        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustForce);
        
        float rotation = -Input.GetAxis("Rotate") * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotation * rotationSpeed);

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            //GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            bulletSpawner._pool.Get();
            Bullet balaScript = bullet.GetComponent<Bullet>();

            bullet.targetVector = transform.right;
        }*/
        HandleShooting();
    
    }

    private void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            Bullet bullet = bulletSpawner._pool.Get();
            Bullet balaScript = bullet.GetComponent<Bullet>();

            bullet.targetVector = transform.right;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        { 
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }           
    }
}
