using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionBox2 : MonoBehaviour
{

    private BoxCollider2D BoxPiece8;
    private BoxCollider2D BoxPiece9;
    private BoxCollider2D BoxPiece10;
    private BoxCollider2D BoxPiece11;
    private BoxCollider2D BoxPiece12;
    private BoxCollider2D BoxPiece13;
    private BoxCollider2D BoxPiece14;
    private BoxCollider2D boxcollider;
    private BoxCollider2D box2collider;
    private BoxCollider2D box2colliderbroken;


    private BoxCollider2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<BoxCollider2D>();

        boxcollider = GameObject.Find("Box1").GetComponent<BoxCollider2D>();
        box2colliderbroken = GameObject.Find("BrokenBox").GetComponent<BoxCollider2D>();
        box2collider = GameObject.Find("Box2").GetComponent<BoxCollider2D>();

        BoxPiece8 = GameObject.Find("BrokenBox2_0").GetComponent<BoxCollider2D>();
        BoxPiece9 = GameObject.Find("BrokenBox2_1").GetComponent<BoxCollider2D>();
        BoxPiece10 = GameObject.Find("BrokenBox2_2").GetComponent<BoxCollider2D>();
        BoxPiece11 = GameObject.Find("BrokenBox2_3").GetComponent<BoxCollider2D>();
        BoxPiece12 = GameObject.Find("BrokenBox2_4").GetComponent<BoxCollider2D>();
        BoxPiece13 = GameObject.Find("BrokenBox2_5").GetComponent<BoxCollider2D>();
        BoxPiece14 = GameObject.Find("BrokenBox2_6").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Physics2D.IgnoreCollision(box2collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(boxcollider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece8.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece9.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece10.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece11.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece12.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece13.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece14.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (collision.gameObject.CompareTag("BrokenBox"))
        {
            Physics2D.IgnoreCollision(box2collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(boxcollider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece8.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece9.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece10.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece11.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece12.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece13.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece14.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }


        if (collision.gameObject.CompareTag("Player"))
        {

            Physics2D.IgnoreCollision(BoxPiece8.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece9.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece10.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece11.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece12.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece13.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece14.GetComponent<Collider2D>(), GetComponent<Collider2D>());


            Physics2D.IgnoreCollision(boxcollider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}