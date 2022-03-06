using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textaboveNPCtest : MonoBehaviour {

    public bool myVar1;


    public void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1f, 1f, 1f, 0f);
    }

    public void Update()
    {
        myVar1 = GameObject.Find("Player").GetComponent<playermovement>().yourVar;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        if (myVar1 == true)
        {
            renderer.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

    SpriteRenderer renderer = GetComponent<SpriteRenderer>();

       
        if (collision.gameObject.name == "Player")
        {
            renderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        renderer.color = new Color(1f, 1f, 1f, 0f);
        myVar1 = false;
    }
}