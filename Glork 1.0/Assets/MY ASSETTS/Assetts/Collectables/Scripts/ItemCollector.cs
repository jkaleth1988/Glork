using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public float cherryCount = 0f;

    [SerializeField] private Text cherryText;
    public int LifeAmount;
    [SerializeField] private Text lifeText;

    void Start()
    {

    }
 
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            
        if (collision.gameObject.CompareTag("YellowGem"))
        {
            Destroy(collision.gameObject);
            cherryCount += 10;
            cherryText.text = "$ " + cherryCount;
        }

        if (collision.gameObject.CompareTag("GreenGem"))
        {
            Destroy(collision.gameObject);
            cherryCount += 25;
            cherryText.text = "$ " + cherryCount;
        }

        if (collision.gameObject.CompareTag("RedGem"))
        {
            Destroy(collision.gameObject);
            cherryCount += 50;
            cherryText.text = "$ " + cherryCount;
        }

        if (collision.gameObject.CompareTag("SilverCoin"))
        {
            Destroy(collision.gameObject);
            cherryCount += 1;
            cherryText.text = "$ " + cherryCount;
        }

        if (collision.gameObject.CompareTag("GoldCoin"))
        {
            Destroy(collision.gameObject);
            cherryCount += 5;
            cherryText.text = "$ " + cherryCount;

        }

    }
}

//private void OnCollisionEnter2D(Collision2D collision)
//{

//}


