using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HouseScroll : MonoBehaviour
{
    Vector2 offset;

    public bool scroller2;
    public float xVelocity;
    public float yVelocity;

    public void Awake()
    {

    }


    void Start()
    {
        offset = new Vector2(xVelocity, yVelocity);
    }


    void Update()
    {
        scroller2 = GameObject.Find("Player").GetComponent<playermovement>().BackgroundScrollBool;

        if (scroller2 == true)
        {
            this.transform.position = offset * Time.deltaTime;
        }
    }
}
