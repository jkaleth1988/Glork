using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletRight : MonoBehaviour
{

    public float speed;
    public bool destroyBullet;
    public Rigidbody2D rb;
    public int bulletHit;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Cube001 hit!");
            Destroy(rb);
            Destroy(gameObject);
        }
    }
}
