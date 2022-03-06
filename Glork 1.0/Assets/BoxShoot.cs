using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxShoot : MonoBehaviour
{

    public int LifeCounter = 3;
    public Animator anim;
    private Rigidbody2D BoxPiece;
    private Rigidbody2D BoxPiece1;
    private Rigidbody2D BoxPiece2;
    private Rigidbody2D BoxPiece3;
    private Rigidbody2D BoxPiece4;
    private Rigidbody2D BoxPiece5;
    private Rigidbody2D BoxPiece6;
    private Rigidbody2D BoxPiece7;
    private BoxCollider2D boxcollider;
    private BoxCollider2D box2collider;
    private BoxCollider2D player;
    private BoxCollider2D bullet;
    public GameObject SilverCoin;
    public GameObject GoldCoin;
    public Rigidbody2D CoinBody;
    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpForceReverse = 5f;
    public Transform CoinAppearLocation;
    bool MyFunctionCalled = false;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
        box2collider = GameObject.Find("Box1").GetComponent<BoxCollider2D>();

        player = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        bullet = GameObject.Find("Bullet(Clone)").GetComponent<BoxCollider2D>();

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
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StandardLaserAttack"))
        {

            LifeCounter--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") && LifeCounter <= 0)
        {
            Physics2D.IgnoreCollision(box2collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Debug.Log("We are colliding");
        }

        if (collision.gameObject.CompareTag("BrokenBox") && LifeCounter <= 0)
        {
            Physics2D.IgnoreCollision(box2collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Debug.Log("We are colliding");

        }

        if (collision.gameObject.CompareTag("Player") && LifeCounter <= 0)
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Debug.Log("Player colliding");
        }

        if (collision.gameObject.CompareTag("StandardLaserAttack") && LifeCounter <= 0)
        {
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Debug.Log("Bullet colliding");
        }
    }

    public void CoinsAppear()
    {

        int random = Random.Range(1, 6);

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
    }

    public void CoinsAppearReverse()
    {

        int random = Random.Range(1, 6);

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
    }

}