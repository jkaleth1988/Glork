using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private int LifeCounter = 20;
    private Color originalColour;
    private bool stopflashing;

    void Start()
    {
        anim = GetComponent<Animator>();
        originalColour = GetComponent<Renderer>().material.color;

    }

    void Update()
    {
        if (LifeCounter == 0)
        {
            anim.SetTrigger("IsEnemyDead");
            stopflashing = true;
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StandardLaserAttack"))
        {
            Debug.Log("Im hitting the enemy!");
            LifeCounter--;


            if (stopflashing == false)
            {
                StartCoroutine("EnemyFlash");
            }
        }
    }
    public IEnumerator EnemyFlash()

{
        GetComponent<Renderer>().material.color = Color.red;
    yield return new WaitForSeconds(0.02f);
    GetComponent<Renderer>().material.color = originalColour;
    StopCoroutine("EnemyFlash");
}
}



