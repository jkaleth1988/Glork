using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundMaterialScroll : MonoBehaviour
{

   Material material;
   Vector2 offset;

   public float xVelocity;
   public float yVelocity;
    public bool scroller;
    public bool scrollerReverse;
    public bool IsInTheBox;
    public bool Dead;

  public void Awake()
  {
  material = GetComponent<Renderer>().material;
  }

   void Start()
  {
    offset = new Vector2(xVelocity, yVelocity);
  }

    // Update is called once per frame
    void Update()
    {
        IsInTheBox = GameObject.Find("BGstopLogic").GetComponent<BGstopmoving>().IsInBox;
        scroller = GameObject.Find("Player").GetComponent<playermovement>().BackgroundScrollBool;
        Dead = GameObject.Find("Player").GetComponent<PlayerLife>().IsDead;

        scrollerReverse = GameObject.Find("Player").GetComponent<playermovement>().BackgroundScrollBoolOpposite;

        if (scroller == true && IsInTheBox == false && Dead == false)
        {
            material.mainTextureOffset += offset * Time.deltaTime;
        }

        if (scrollerReverse == true && IsInTheBox == false && Dead == false)
        {
            material.mainTextureOffset -= offset * Time.deltaTime;
        }
    }
}
