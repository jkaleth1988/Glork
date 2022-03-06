using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1Shoot : MonoBehaviour
{

    public int LifeCounter = 30;
    public Animator anim;

    private BoxCollider2D boxcollider;
    private BoxCollider2D box2collider;
    private BoxCollider2D player;
    private BoxCollider2D bullet;
    public GameObject SilverCoin;
    public GameObject GoldCoin;
    public GameObject ExtraLife;
    public Rigidbody2D CoinBody;
    public Rigidbody2D CoinBody2;
    public Rigidbody2D LifeBody;
    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpForceReverse = 5f;
    public Transform CoinAppearLocation;
    bool MyFunctionCalled = false;


    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        boxcollider = GameObject.Find("Box1").GetComponent<BoxCollider2D>();
        box2collider = GameObject.Find("Box2").GetComponent<BoxCollider2D>();

        player = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        bullet = GameObject.Find("Bullet").GetComponent<BoxCollider2D>();

        

        if (LifeCounter <= 0)
        {
            CoinsAppear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeCounter <= 0 && MyFunctionCalled == false)
        {
           
                MyFunctionCalled = true;
                CoinsAppear();
            CoinsAppearReverse();
            anim.SetTrigger("BoxDestroyed");
       }

        if (LifeCounter <= 0)
        {
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StandardLaserAttack"))
        {

            LifeCounter--;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {

            LifeCounter--;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && LifeCounter <= 0)
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }

        if (collision.gameObject.CompareTag("StandardLaserAttack") && LifeCounter <= 0)
        {
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }
    }

    public void CoinsAppear()
    {

        int random = Random.Range(1, 21);

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
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 11)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 12)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 13)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 14)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 15)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 16)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 17)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 18)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 19)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForce, jumpForce));
        }

        else if (random == 20)
        {
            var extraLife = Instantiate(ExtraLife, CoinAppearLocation.position, CoinAppearLocation.rotation);
            LifeBody = extraLife.GetComponent<Rigidbody2D>();
            LifeBody.AddForce(new Vector2(jumpForce, jumpForce));
        }


    }

    public void CoinsAppearReverse()
    {

        int random = Random.Range(1, 21);

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

        if (random == 5)
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
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 11)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 12)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 13)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 14)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 15)
        {
            var silverCoin = Instantiate(SilverCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody = silverCoin.GetComponent<Rigidbody2D>();
            CoinBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 16)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 17)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 18)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 19)
        {
            var goldCoin = Instantiate(GoldCoin, CoinAppearLocation.position, CoinAppearLocation.rotation);
            CoinBody2 = goldCoin.GetComponent<Rigidbody2D>();
            CoinBody2.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }

        else if (random == 20)
        {
            var extraLife = Instantiate(ExtraLife, CoinAppearLocation.position, CoinAppearLocation.rotation);
            LifeBody = extraLife.GetComponent<Rigidbody2D>();
            LifeBody.AddForce(new Vector2(jumpForceReverse, jumpForce));
        }


    }

    public void DestroyBox()
    {
        Destroy(gameObject); 
    }

}