using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    private BoxCollider2D box2collider;
    private BoxCollider2D box2colliderbroken;
    private BoxCollider2D BoxPiece;
    private BoxCollider2D BoxPiece1;
    private BoxCollider2D BoxPiece2;
    private BoxCollider2D BoxPiece3;
    private BoxCollider2D BoxPiece4;
    private BoxCollider2D BoxPiece5;
    private BoxCollider2D BoxPiece6;
   private BoxCollider2D BoxPiece7;

    private BoxCollider2D player;
    private BoxCollider2D bullet;
    private BoxCollider2D boxcollider;
    private Rigidbody2D RB;
    private BoxCollider2D silverCoin;

    [SerializeField] public float sideForce;
    [SerializeField] public float upForce;

    private bool isBroken;





    // Start is called before the first frame update
    void Start()
    {
        box2colliderbroken = GameObject.Find("BrokenBox").GetComponent<BoxCollider2D>();
        box2collider = GameObject.Find("Box2").GetComponent<BoxCollider2D>();
        boxcollider = GameObject.Find("Box1").GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        bullet = GameObject.Find("Bullet").GetComponent<BoxCollider2D>();

            BoxPiece = GameObject.Find("BrokenBox1_0").GetComponent<BoxCollider2D>();
        BoxPiece1 = GameObject.Find("BrokenBox1_1").GetComponent<BoxCollider2D>();
        BoxPiece2 = GameObject.Find("BrokenBox1_2").GetComponent<BoxCollider2D>();
        BoxPiece3 = GameObject.Find("BrokenBox1_3").GetComponent<BoxCollider2D>();
        BoxPiece4 = GameObject.Find("BrokenBox1_4").GetComponent<BoxCollider2D>();
        BoxPiece5 = GameObject.Find("BrokenBox1_5").GetComponent<BoxCollider2D>();
        BoxPiece6 = GameObject.Find("BrokenBox1_6").GetComponent<BoxCollider2D>();
        BoxPiece7 = GameObject.Find("BrokenBox1_8").GetComponent<BoxCollider2D>();
        box2collider = GameObject.Find("BrokenBox").GetComponent<BoxCollider2D>();

        silverCoin = GameObject.Find("Silver Coin").GetComponent<BoxCollider2D>();

        isBroken = false;

        RB = GetComponent<Rigidbody2D>();

        RB.AddForce(new Vector3(upForce, sideForce));
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Physics2D.IgnoreCollision(boxcollider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(box2collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece3.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece4.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece5.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece6.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece7.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }

        if (collision.gameObject.CompareTag("BrokenBox"))
        {
            Debug.Log("Pieces colliding");
            Physics2D.IgnoreCollision(boxcollider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(box2colliderbroken.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece3.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece4.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece5.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece6.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece7.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }

        if (collision.gameObject.CompareTag("Player"))
        {
       
            Physics2D.IgnoreCollision(BoxPiece.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece3.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece4.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece5.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece6.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece7.GetComponent<Collider2D>(), GetComponent<Collider2D>());


            Physics2D.IgnoreCollision(boxcollider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }


        if (collision.gameObject.CompareTag("StandardLaserAttack"))
        {
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece3.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece4.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece5.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece6.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece7.GetComponent<Collider2D>(), GetComponent<Collider2D>());


            Physics2D.IgnoreCollision(boxcollider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
