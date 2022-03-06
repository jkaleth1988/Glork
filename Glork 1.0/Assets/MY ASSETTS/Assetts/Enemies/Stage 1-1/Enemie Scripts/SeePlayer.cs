using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePlayer : MonoBehaviour
{
    private Animator anim;
    private Animator anim2;
    private Animator anim3;
    public int isInTheZoner;
    public bool isInTheZone;
    public Transform Player;
    private SpriteRenderer spriteRenderer;



    public GameObject EnemyBullet;
    private GameObject instantiatedObj;
    public Transform EnemyFirePoint;
    public int BulletHit;
    public bool EnemyDead;


    float normValue;
    // Start is called before the first frame update

    public void Awake()
    {

    }

    void Start()
    {
        EnemyDead = false;
        anim = GameObject.Find("Enemy2").GetComponent<Animator>();
        EnemyDead = GameObject.Find("Enemy2").GetComponent<Enemy2Hurt>().enemyDead;
    }


    // Update is called once per frame
    void Update()
    {
        

        if (EnemyDead == true)
        {
            CancelInvoke("InstantiateObject");
        }

        if (EnemyDead == true && isInTheZoner == 1)
        {
            Destroy(EnemyBullet);
            CancelInvoke("InstantiateObject");
        }
    }

    public void InstantiateObject()
    {


        instantiatedObj = Instantiate(EnemyBullet, EnemyFirePoint.position, EnemyFirePoint.rotation);
        Destroy(instantiatedObj, 5f);


    }

    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {

            
            normValue = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            InvokeRepeating("InstantiateObject", 0.4f, 1.4f);
            //Invoke("InstantiateObject", 0.4f);
            isInTheZoner = 1;
            anim.SetBool("SeePlayer", true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            isInTheZoner = 0;
            CancelInvoke("InstantiateObject");
            anim.SetBool("SeePlayer", false);
            anim.Play("CrickWalk", 0, normValue);
        }
    }

    //IEnumerator countdownToShoot()
    //{

    //    instantiatedObj = Instantiate(EnemyBullet, EnemyFirePoint.position, EnemyFirePoint.rotation);
    //    yield return new WaitForSeconds(1.4f);
    //    Destroy(instantiatedObj, 5f);
      

    //    //if (isInTheZoner == 1)
    //    //{

    //    //    StartCoroutine(countdownToShoot());
    //    //}

    //    if (isInTheZoner == 0)
    //    {
    //        yield break;
    //    }
    //}
}