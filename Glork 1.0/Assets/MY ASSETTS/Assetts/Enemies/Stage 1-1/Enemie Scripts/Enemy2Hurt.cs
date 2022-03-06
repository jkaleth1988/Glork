using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Hurt : MonoBehaviour
{
    private Animator anim;
    public int LifeCounter = 100;
    private Rigidbody2D RB;
    private int counter = 0;
    public Transform CoinAppearLocation;
    public GameObject SilverCoin;
    public GameObject GoldCoin;
    public Rigidbody2D CoinBody;
    public Rigidbody2D CoinBody2;
    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpForceReverse = 5f;

    public float speed = 0.01f;

    public bool enemyDead;

    void Start()
    {

     
        enemyDead = false;
        anim = this.GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (LifeCounter <= 0 && anim.GetBool("SeePlayer"))
        {
            anim.SetTrigger("IsEnemyDead");
            enemyDead = true;          
            Destroy(RB);
        }

        else if (LifeCounter <= 0 && anim.GetBool("ConfusedLeft"))
        {

            anim.SetTrigger("IsEnemyDead");
            enemyDead = true;
            Destroy(RB);
        }

        if (LifeCounter <= 0 && anim.GetBool("SPright"))
        {
            anim.SetTrigger("IsEnemyDeadRight");
            enemyDead = true;
            Destroy(RB);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StandardLaserAttack"))
        {
            
            LifeCounter--;
        }
    }

    public void DeadEvent(string message)
    {
        if (message.Equals("Dead"))
        {
            CoinsAppear();
            CoinAppearsReverse();
            BonusSpawnChance();


            // Do other things based on an attack ending.
        }
    }

    public void CoinsAppear()
    {

        int random = Random.Range(1, 13);


        
        if (random == 1)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 2)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 3)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 4)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 5)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 6)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 7)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 8)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 9)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 10)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 11)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 12)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForce, jumpForce));
        }
    }

    public void CoinAppearsReverse()
    {

        int random = Random.Range(1, 13);



        if (random == 1)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 2)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 3)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 4)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 5)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 6)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 7)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 8)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 9)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 10)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 11)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 12)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

    }

    public void BonusSpawnChance()
    {

        int random = Random.Range(1, 25);


        if (random == 1)
        { 
        }

        else if (random == 2)
        {
        }

        else if (random == 3)
        {
        }

        else if (random == 4)
        {
        }

        else if (random == 5)
        {
        }

        else if (random == 6)
        {
        }

        else if (random == 7)
        {
        }

        else if (random == 8)
        {
        }

        else if (random == 9)
        {
        }

        else if (random == 10)
        {
        }

        else if (random == 11)
        {
        }

        else if (random == 12)
        {
        }

        else if (random == 13)
        {
        }


        else if (random == 14)
        {
        }

        else if (random == 15)
        {
        }

        else if (random == 16)
        {
        }

        else if (random == 17)
        {

            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));

            var silverCoin2 = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin2.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 18)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));

            var silverCoin2 = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin2.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));

        }

        else if (random == 19)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));

            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 20)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));

            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForce, jumpForce));

        }

        else if (random == 21)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForceReverse, jumpForce));

            var goldCoin2 = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin2.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 22)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForceReverse, jumpForce));

            var goldCoin2 = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin2.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 23)
        {
        }

        else if (random == 24)
        {
        }


    }
}

//clone.rigidbody.AddForce(clone.transform.forward * projectileSpeed, ForceMode.Impulse);

