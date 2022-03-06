//
//{
//    public bool IsShooting = false;
//    public Transform firePoint;
//    private GameObject Bullet;
  

//    // Start is called before the first frame update
//    //void Start()
//    //{

//    //    IsShooting = false;
//    //}

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKey(KeyCode.E))
//        {
//            Shoot();
//            IsShooting = true;
//        }

//        else
//        {
//            IsShooting = false;
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)

//    {
//        if (collision.gameObject.CompareTag("PeaEnemy"))
//        {



//             DestroyImmediate(gameObject, true);

//            Debug.Log("Im hitting the enemy!");


//            var newObj = GameObject.Instantiate(Bullet, transform.position, transform.rotation);

//            newObj.transform.parent = GameObject.Find("Player").transform;

//        }
//    }

    //private void Flip()
    //{



    //    transform.Rotate(0f, 180f, 0f);
    //}

    //void Shoot()
    //{
    //    Instantiate(Bullet, firePoint.position, firePoint.rotation);

    //}
