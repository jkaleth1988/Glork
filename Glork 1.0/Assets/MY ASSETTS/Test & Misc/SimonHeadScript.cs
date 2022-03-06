using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonHeadScript : MonoBehaviour
{
    public bool myVar2;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        myVar2 = GameObject.Find("Player").GetComponent<playermovement>().yourVar;

        if (myVar2 == true)
        {
            anim.SetBool("headone", true);
        }

    }
}

