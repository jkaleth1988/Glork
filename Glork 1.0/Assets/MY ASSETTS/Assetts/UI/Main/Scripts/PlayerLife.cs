using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    [SerializeField] private Text lifeText;
    private SpriteRenderer bulletPrefab;
    private Bullet bulletPrefab2;
    private Weapon bulletPrefab3;
    public static int lifeAmount = 3;
    private Rigidbody2D RB;
    public bool IsDead;
    private Animator CrickLaugh;
    private BoxCollider2D Collider;
    private int IsInZoneLeft;
    private int IsInZoneRight;
    public bool invincible;
    public int lifeCounter;
    private Animator Hearts;
    private bool removeScript;


    void Start()
    {
        lifeCounter = 3;


        invincible = false;
        Hearts = GameObject.Find("HeartBoxParent").GetComponent<Animator>();
        bulletPrefab = GameObject.Find("Bullet").GetComponent<SpriteRenderer>();
        bulletPrefab2 = GameObject.Find("Bullet").GetComponent<Bullet>();
        bulletPrefab3 = GameObject.Find("Player").GetComponent<Weapon>();
        lifeText.text = "x " + lifeAmount;
        anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
        CrickLaugh = GameObject.Find("Enemy2").GetComponent<Animator>();
        IsInZoneRight = GameObject.Find("Detect PlayerFACINGRIGHT").GetComponent<SeePlayerFacingRight>().isInTheZoner;
        IsInZoneLeft = GameObject.Find("Detect Player").GetComponent<SeePlayer>().isInTheZoner;



    }

    void Update()
    {
 
        invincible = GameObject.Find("DEBUG MENU").GetComponent<TurnOffDamage>().Invincibility;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CrickEnemy") && invincible == false || collision.gameObject.CompareTag("PeaEnemy") && invincible == false || collision.gameObject.CompareTag("Trap") && invincible == false)
        {
            lifeCounter--;
            Hearts.SetTrigger("LifeDown");



            if (lifeCounter == 0)
            {
                removeScript = GameObject.Find("Player").GetComponent<playermovement>().enabled = false;
                Die();
            }
        }
    }

    private void Die()
    {
        bulletPrefab3.enabled = false;
        bulletPrefab.enabled = false;
        bulletPrefab2.enabled = false;

        Hearts.SetTrigger("NoLives");
        CrickLaugh.SetTrigger("IsPlayerDead");
        IsDead = true;
        anim.SetTrigger("TriggerDeath");
        Destroy(Collider);
        RB.bodyType = RigidbodyType2D.Static;
        lifeAmount -= 1;
        lifeText.text = "x " + lifeAmount;
    }


    private void RestartLevel()
    {
        if (lifeAmount > 0)
        {
            StartCoroutine(countdownToStart());
            GameObject.Find("Player").GetComponent<playermovement>().yourVar = false;
        }

        if (lifeAmount == 0)
        {
            StartCoroutine(countdownToGameOver());
            GameObject.Find("Player").GetComponent<playermovement>().yourVar = false;
        }
    }

    IEnumerator countdownToStart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator countdownToGameOver()
    {
        yield return new WaitForSeconds(5f);
        lifeAmount = 3;
        SceneManager.LoadScene("End Game");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("ExtraLife"))
        {
            lifeAmount += 1;
            lifeText.text = "x " + lifeAmount;
            Destroy(collision.gameObject);

            //cherryText.text = "$ " + cherryCount;

        }

    }
}
