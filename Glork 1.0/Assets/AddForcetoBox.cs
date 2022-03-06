using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForcetoBox : MonoBehaviour
{
    public Rigidbody2D BoxPiece;
    public Rigidbody2D BoxPiece1;
    public Rigidbody2D BoxPiece2;
    public Rigidbody2D BoxPiece3;
    public Rigidbody2D BoxPiece4;
    public Rigidbody2D BoxPiece5;
    public Rigidbody2D BoxPiece6;
    public Rigidbody2D BoxPiece7;

    [SerializeField] public float Force1 = 7f;
    [SerializeField] public float Force2 = 5f;
    [SerializeField] public float Force3 = 5f;
    [SerializeField] public float Force4 = 3f;

    public int BoxForceRepeat;

    // Start is called before the first frame update
    void Start()
    {


        BoxPiece.AddForce(new Vector2(Force3, Force4));
        BoxPiece1.AddForce(new Vector2(Force1, Force2));
        BoxPiece2.AddForce(new Vector2(Force1, Force2));
        BoxPiece3.AddForce(new Vector2(Force3, Force4));
        BoxPiece4.AddForce(new Vector2(Force1, Force2));
        BoxPiece5.AddForce(new Vector2(Force3, Force4));
        BoxPiece6.AddForce(new Vector2(Force3, Force4));
        BoxPiece7.AddForce(new Vector2(Force1, Force2));

    }

    // Update is called once per frame
    void Update()
    {
        BoxPiece = GameObject.Find("BrokenBox1_0").GetComponent<Rigidbody2D>();
        BoxPiece1 = GameObject.Find("BrokenBox1_1").GetComponent<Rigidbody2D>();
        BoxPiece2 = GameObject.Find("BrokenBox1_2").GetComponent<Rigidbody2D>();
        BoxPiece3 = GameObject.Find("BrokenBox1_3").GetComponent<Rigidbody2D>();
        BoxPiece4 = GameObject.Find("BrokenBox1_4").GetComponent<Rigidbody2D>();
        BoxPiece5 = GameObject.Find("BrokenBox1_5").GetComponent<Rigidbody2D>();
        BoxPiece6 = GameObject.Find("BrokenBox1_6").GetComponent<Rigidbody2D>();
        BoxPiece7 = GameObject.Find("BrokenBox1_8").GetComponent<Rigidbody2D>();

    }
}
