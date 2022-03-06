using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public int playerGrounded;
    public bool EverythingPaused;

    void Start()
    {
 
    }


    void Update()
    {

        EverythingPaused = GameObject.Find("Player").GetComponent<playermovement>().pauseEverything;
        playerGrounded = GameObject.Find("Player").GetComponent<playermovement>().IsGroundedShoot;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerGrounded == 1 && EverythingPaused == false)
            {
                InvokeRepeating("Shoot", 0f, 0.3f);

            }

            else if (playerGrounded == 0 && EverythingPaused == false)
            {
                Invoke("Shoot", 0f);

            }
        }

        if (Input.GetKeyUp(KeyCode.E) || EverythingPaused == true)
        {
            CancelInvoke("Shoot");
        }

        if (Input.GetKeyDown(KeyCode.Space) || EverythingPaused == true)
        {
            CancelInvoke("Shoot");
        }
    }
    

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       


    }
}
