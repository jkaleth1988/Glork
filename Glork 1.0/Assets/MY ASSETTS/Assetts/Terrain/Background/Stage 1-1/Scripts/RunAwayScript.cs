using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayScript : MonoBehaviour
{
    private Animator anim;




    void Start()
    {
        anim = GetComponent<Animator>();
    }




    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            anim.SetBool("IsNearPlayer", true);
        }
    }
}
