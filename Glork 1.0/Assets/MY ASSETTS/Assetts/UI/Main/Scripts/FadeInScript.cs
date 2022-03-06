using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScript : MonoBehaviour
{
    public Animator anim;
    public bool IsPlayerDead;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("HasDied", false);
        IsPlayerDead = GameObject.Find("Player").GetComponent<PlayerLife>().IsDead;

    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlayerDead == true)
        {
            Debug.Log("Yo");
            anim.SetBool("HasDied", true);
        }
    }
}
