using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IsOnQuitScript : MonoBehaviour
{
    public bool IsOnQuit;
    public bool IsNotTransitioning;
    public bool ThisMethod;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        IsOnQuit = false;
        IsNotTransitioning = false;
        ThisMethod = false;
    }

    // Update is called once per frame
    void Update()
    {

        QuitMethod();
        
    }

    void QuitMethod()
    {
        StartCoroutine(countdownToThisMethod());

        if (ThisMethod == true)
        {

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                anim.SetBool("IsOnQuit", true);
                Debug.Log("Should be on quit here");
                IsOnQuit = true;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                anim.SetBool("IsOnQuit", false);
                Debug.Log("Should be on  back to menu here");
                IsOnQuit = false;
            }

            if (IsOnQuit == true)

            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {

                    anim.SetBool("Fade", true);
                    StartCoroutine(countdownToQuit());
                }
            }

            if (IsOnQuit == false)

            {

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {

                    anim.SetBool("Fade", true);
                    StartCoroutine(countdownToRestart());
                }
            }
        }

        IEnumerator countdownToThisMethod()
        {
            yield return new WaitForSeconds(4f);
            ThisMethod = true;
        }

        IEnumerator countdownToRestart()
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("Happy Hills 1-1");
        }

        IEnumerator countdownToQuit()
        {
            yield return new WaitForSeconds(1.5f);
            Application.Quit();
        }
    }
    }
