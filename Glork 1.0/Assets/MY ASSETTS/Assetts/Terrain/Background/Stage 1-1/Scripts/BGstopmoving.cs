using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGstopmoving : MonoBehaviour
{

    public bool IsInBox;
    public bool LevelStart;
    // Start is called before the first frame update
    void Start()
    {
        StartCountdown();
    }

    // Update is called once per frame
    void Update()
    {

    }




    public void StartCountdown()
    {
        if (LevelStart == true)
        {
            StartCoroutine(countdownToStart());
        }
    }

    IEnumerator countdownToStart()
    {
        IsInBox = true;
        yield return new WaitForSeconds(1f);
        IsInBox = false;
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            IsInBox = true;
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            IsInBox = false;
        }
    }
}
