using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simon1stLine : MonoBehaviour
{

    private Animator anim;
    public Text instruction;
    public bool myVar3;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        instruction = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMyVar();

        if (myVar3 == true)
        {
            anim.SetBool("ViewText", true);
            instruction.text = "yo";
            myVar3 = false;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0) && myVar3 == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                instruction.text = "yo";
            }
        }
    }

    public void CheckMyVar()
    {
        myVar3 = GameObject.Find("Player").GetComponent<playermovement>().yourVar;
    }
}