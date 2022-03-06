using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 0.01f;
    public bool destroyBullet;
    public Rigidbody2D rb;
    public int bulletHit;

    public GameObject bulletimpact;
    public GameObject gunshootimpact;
    private GameObject myImpactVar;
    private GameObject myVar;

    public Transform impactPoint;
    public Transform firePoint;

    void Start()
    {
        rb.velocity = -transform.right * speed;

        myVar = Instantiate(gunshootimpact, firePoint.position, firePoint.rotation);
    }

    void Update()
    {
        Destroy(myVar, 1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            Destroy(rb);
            Destroy(gameObject);
            myImpactVar = Instantiate(bulletimpact, impactPoint.position, impactPoint.rotation);
            Destroy(myImpactVar, 1f);
        }

        if (collision.gameObject.name == "Box1")
        {
            Destroy(rb);
            Destroy(gameObject);
            myImpactVar = Instantiate(bulletimpact, impactPoint.position, impactPoint.rotation);
            Destroy(myImpactVar, 1f);
        }


        if (collision.gameObject.name == "Box2")
        {
            Destroy(rb);
            Destroy(gameObject);
            myImpactVar = Instantiate(bulletimpact, impactPoint.position, impactPoint.rotation);
            Destroy(myImpactVar, 1f);
        }

        if (collision.gameObject.name == "Terrain")
        {
            Destroy(rb);
            Destroy(gameObject);
        }
    }
}
