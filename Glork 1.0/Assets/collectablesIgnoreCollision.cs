using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectablesIgnoreCollision : MonoBehaviour
{

    private BoxCollider2D box2collider;
    private BoxCollider2D BoxPiece;
    private BoxCollider2D BoxPiece1;
    private BoxCollider2D BoxPiece2;
    private BoxCollider2D BoxPiece3;
    private BoxCollider2D BoxPiece4;
    private BoxCollider2D BoxPiece5;
    private BoxCollider2D BoxPiece6;
    private BoxCollider2D BoxPiece7;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BoxPiece = GameObject.Find("BrokenBox1_0").GetComponent<BoxCollider2D>();
        BoxPiece1 = GameObject.Find("BrokenBox1_1").GetComponent<BoxCollider2D>();
        BoxPiece2 = GameObject.Find("BrokenBox1_2").GetComponent<BoxCollider2D>();
        BoxPiece3 = GameObject.Find("BrokenBox1_3").GetComponent<BoxCollider2D>();
        BoxPiece4 = GameObject.Find("BrokenBox1_4").GetComponent<BoxCollider2D>();
        BoxPiece5 = GameObject.Find("BrokenBox1_5").GetComponent<BoxCollider2D>();
        BoxPiece6 = GameObject.Find("BrokenBox1_6").GetComponent<BoxCollider2D>();
        BoxPiece7 = GameObject.Find("BrokenBox1_8").GetComponent<BoxCollider2D>();
        box2collider = GameObject.Find("BrokenBox").GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BrokenBox"))
        {
            Physics2D.IgnoreCollision(BoxPiece.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece3.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece4.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece5.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece6.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BoxPiece7.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(box2collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Debug.Log("Coin colliding");
        }
    }
}
