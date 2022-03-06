using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{

    private Rigidbody2D ItemBody;


    void Start()
    {
        ItemBody = GameObject.Find("Silver Coin").GetComponent<Rigidbody2D>();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D currentObject = collision;
        if (currentObject != null)
        {
            if (currentObject.gameObject.CompareTag("Ground"))
            {
                if (ItemBody != null)
                {
                    ItemBody.velocity = Vector2.zero;
                    GetComponent<Collider2D>().isTrigger = false;
                }
            }
        }
    }


    // private bool IsGroundedMethod()
    // {
    //  return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    //   }

}
