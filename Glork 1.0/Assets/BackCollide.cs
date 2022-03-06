using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCollide : MonoBehaviour
{
    public bool hitBackRight = false;
    public bool hitBackLeft = false;

    private Animator anim;
    private Animator anim2;
    public bool isInZone;
    private int DirectionX;

    float normValue;


    void Start()
    {
        anim = GameObject.Find("Enemy2").GetComponent<Animator>();
        anim2 = GameObject.Find("CrickHead").GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DirectionX = GameObject.Find("Player").GetComponent<playermovement>().storedDirection;
        isInZone = GameObject.Find("Enemy2").GetComponent<SeePlayer>().isInTheZone;
        HitinTheBackFacingRight();
        HitinTheBackFacingLeft();
    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("StandardLaserAttack"))
        {
            if (DirectionX == 1)
            {
                normValue = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
                Debug.Log(collision.name);
                hitBackRight = true;
                StartCoroutine("Timer");
            }

            if (DirectionX == -1)
            {
                normValue = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
                Debug.Log(collision.name);
                hitBackLeft = true;
                StartCoroutine("Timer");
            }
        }
    }


    public IEnumerator Timer()

    {
        yield return new WaitForSeconds(1f);
        hitBackRight = false;
        hitBackLeft = false;

        if (hitBackRight == false && isInZone == false || hitBackLeft == false && isInZone == false)
        {
            anim.Play("CrickWalk", 0, normValue);
            StopCoroutine("Timer");
        }

        else
        {
          
        }

    }

    public void HitinTheBackFacingRight()
    {
        if (hitBackRight == true && isInZone == true)
        {         
            anim.SetBool("SeePlayer", true);
            anim2.SetBool("SeePlayer", true);
        }

        else if (hitBackRight == false)
        {
            anim.SetBool("SeePlayer", false);
            anim2.SetBool("SeePlayer", false);
        }
    }

    public void HitinTheBackFacingLeft()
    {
        if (hitBackLeft == true && isInZone == true)
        {
            anim.SetBool("SPright", true);
            anim2.SetBool("SPright", true);
        }

        else if (hitBackLeft == false)
        {
            anim.SetBool("SPright", false);
            anim2.SetBool("SPright", false);
        }
    }
}
