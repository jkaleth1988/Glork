using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfHitRightSide : MonoBehaviour
{
    public int IsInZone;
    private Animator anim;

    void Start()
    {
        anim = GameObject.Find("Enemy2").GetComponent<Animator>();
    }


    void Update()
    {


        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
        {
            anim.SetBool("ConfusedRight", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("StandardLaserAttack"))
        {
            anim.SetBool("ConfusedRight", true);
        }
    }
}
