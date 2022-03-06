using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartFlashRed : MonoBehaviour
{

    private Color originalColor;
    private bool stopflashing = false;
    public int lifeCounter;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StandardLaserAttack"))
        {

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
        GetComponent<Renderer>().material.color = originalColor;
        StopCoroutine("EnemyFlash");
    }
}
