using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnBackToMenuScript : MonoBehaviour
{
    public bool IsOnQuitFade = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        IsOnQuitFade = GameObject.Find("Canvas").GetComponent<IsOnQuitScript>().IsOnQuit;
}

    // Update is called once per frame
    void Update()
    {
        if (IsOnQuitFade == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                anim.SetBool("Fade", true);
            }
        }
    }
}
