using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;

    public Rigidbody2D rb;

    private BoxCollider2D BoxPiece;
    private BoxCollider2D BoxPiece1;
    private BoxCollider2D BoxPiece2;
    private BoxCollider2D BoxPiece3;
    private BoxCollider2D BoxPiece4;
    private BoxCollider2D BoxPiece5;
    private BoxCollider2D BoxPiece6;
    private BoxCollider2D BoxPiece7;

    [SerializeField] public GameObject bulletimpactEffect;
    [SerializeField] public Transform impactPoint;
    public GameObject myImpactVar;

    [SerializeField] public GameObject bulletshootEffect;
    [SerializeField] public Transform firePoint;
    public GameObject myVar;

    public bool itsbeendestroyed;


    void Start()
    {
        itsbeendestroyed = false;
        rb.velocity = transform.right * speed;

        myVar = Instantiate(bulletshootEffect, firePoint.position, firePoint.rotation);
    }

    void Update()
    {


    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PeaEnemy"))
        {
            Destroy(gameObject);
            CreateIt();
        }

        if (collision.gameObject.CompareTag("CrickEnemy"))
        {
            Destroy(gameObject);
            CreateIt();

        }

        if (collision.gameObject.CompareTag("Box"))
        {
            Destroy(gameObject);
            CreateIt();
            
        }
    }



    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletBoundary"))
        {
            Destroy(gameObject);
            Destroy(myVar);
        }
    }

    void CreateIt()
    {
        myImpactVar = Instantiate(bulletimpactEffect, impactPoint.position, impactPoint.rotation);
        Destroy(myImpactVar, 1f);
    }
}

