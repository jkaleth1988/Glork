using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public Rigidbody2D PlayerRigidBody;
    private BoxCollider2D coll;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask jumpableGround2;
    private SpriteRenderer sprite;
    private SpriteRenderer sprite2;
    private SpriteRenderer sprite3;
    private SpriteRenderer bulletsprite;
    private Transform bulletspritetransform;
    private Transform moveArmUp;
    private Animator firepointposition;
    public bool pauseEverything;


    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;
    public float directionX = 0f;
    public float HangTime = 0f;
    public float HangCounter;

    public int combinedVar = 0;

    public bool yourVar = false;
    public bool keyCodeUp = false;
    public bool isInBox = false;
    public bool TextBoxVanish;
    public bool BackgroundScrollBool;
    public bool BackgroundScrollBoolOpposite;
    public bool gameIsPaused2;
    public bool LevelStart = true;
    public bool ShootBool;
    public bool m_isGoingRight = true;
    private SpriteRenderer bulletPrefab;
    private Bullet bulletPrefab2;
    private Weapon bulletPrefab3;
    public int IsGroundedShoot;
    private Animator gunposition;
    public int firepointrunonce;

    public bool FirePointUpRightBool;
    public bool shootfixer;

    public int storedDirection;

    private enum MovementState { idle, running, jumping, falling, gunup }

    private MovementState state;

    private Vector3 originalPos;

    private Quaternion originalRot;


    public void Awake()
    {
    }

    // Start is called before the first frame update
    public void Start()
    {



        storedDirection = 0;
        bulletPrefab = GameObject.Find("Bullet").GetComponent<SpriteRenderer>();
        bulletPrefab2 = GameObject.Find("Bullet").GetComponent<Bullet>();
        bulletPrefab3 = GameObject.Find("Player").GetComponent<Weapon>();
        firepointposition = GameObject.Find("FirePoint").GetComponent<Animator>();

        PlayerRigidBody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        gunposition = GameObject.Find("Weak Laser Gun").GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        bulletsprite = GameObject.Find("FirePoint").GetComponent<SpriteRenderer>();
        bulletspritetransform = GameObject.Find("FirePoint").GetComponent<Transform>();
        moveArmUp = GameObject.Find("Weak Laser Gun").GetComponent<Transform>();

        //sprite3 = GameObject.Find("Bullet").GetComponent<SpriteRenderer>();

        StartCountdown();

        sprite2 = GameObject.Find("Weak Laser Gun").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        //    TextBoxVanish = GameObject.Find("Text").GetComponent<Textscript>().VanishVar;

        if (Input.GetKey(KeyCode.E) && IsGrounded() || Input.GetKey(KeyCode.E) && IsGrounded2())
        {
            PlayerRigidBody.bodyType = RigidbodyType2D.Static;
        }

        if (IsGrounded() || IsGrounded2())
        {
            IsGroundedShoot = 1;
            HangCounter = HangTime;
        }
        else
        {
            IsGroundedShoot = 0;
            HangCounter -= Time.deltaTime;
        }

        gameIsPaused2 = GameObject.Find("PauseCanvas").GetComponent<PauseMenu>().GamePause;

        directionX = Input.GetAxisRaw("Horizontal");

        PlayerRigidBody.velocity = new Vector2(directionX * moveSpeed, PlayerRigidBody.velocity.y);



        // TEMPORARILY turned off jumping whilst holding Up (and also further down in code)


        if (Input.GetButtonDown("Jump") && IsGrounded() && !Input.GetKey(KeyCode.UpArrow) && pauseEverything == false || Input.GetButtonDown("Jump") && IsGrounded2() && !Input.GetKey(KeyCode.UpArrow) && pauseEverything == false)
        {
            //IsGroundedShoot = 0;
            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;
            PlayerRigidBody.velocity = new Vector2(PlayerRigidBody.velocity.x, jumpForce);
        }


            // if grounded and press shoot

            if (Input.GetKeyDown(KeyCode.E) && IsGrounded() && pauseEverything == false || Input.GetKeyDown(KeyCode.E) && IsGrounded2() && pauseEverything == false)
        {
            InvokeRepeating("IdleWhenShoot", 0.1f, 0f);
        }



        // if NOT grounded and press shoot

        if (Input.GetKeyDown(KeyCode.E) && !IsGrounded() || Input.GetKeyDown(KeyCode.E) && !IsGrounded2())
        {
            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;

        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.E) && !IsGrounded() && m_isGoingRight == true && pauseEverything == false || Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.E) && !IsGrounded2() && m_isGoingRight == true && pauseEverything == false)
        {
            firepointposition.SetBool("gunupright", true);
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);


            gunposition.SetBool("GunUpRight", true);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);

            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;

        }
        if (Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E) && !IsGrounded() && m_isGoingRight == true && pauseEverything == false || Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E) && !IsGrounded2() && m_isGoingRight == true && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", true);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);


            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);

            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;

        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.E) && !IsGrounded() && m_isGoingRight == false && pauseEverything == false || Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.E) && !IsGrounded2() && m_isGoingRight == false && pauseEverything == false)
        {
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupleft", true);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);


            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", true);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);

            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;

        }
        if (Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E) && !IsGrounded() && m_isGoingRight == false && pauseEverything == false || Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E) && !IsGrounded2() && m_isGoingRight == false && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnleft", true);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);


            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", true);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);

            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;

        }

        /* 1. If looking right and press shoot key down
         * 2. If looking right and press shoot key up
         * 3. if looking right, holding down shoot and pressing Up key down
         * 4. if looking right, holding down shoot and pressing Up key up
         * 5. if looking right, holding down Up and pressing shoot key down
         * 6. if looking right, holding down Up and pressing shoot key up
         * 7. if looking right, pressing down Up and shoot at the same time
         * 8. if looking right, releasing Up and shoot at the same time
         * 
         * 
         * 
         */


        // 1. if looking right and press shoot key down
        if (m_isGoingRight == true && Input.GetKey(KeyCode.E) && IsGrounded() && !Input.GetKey(KeyCode.UpArrow) && pauseEverything == false || m_isGoingRight == true && Input.GetKey(KeyCode.E) && !Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded() && pauseEverything == false || (m_isGoingRight == true && Input.GetKey(KeyCode.E) && IsGrounded2() && !Input.GetKey(KeyCode.UpArrow) && pauseEverything == false || m_isGoingRight == true && Input.GetKey(KeyCode.E) && !Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded2() && pauseEverything == false))
        {
            firepointposition.SetBool("gunidle", true);
            firepointposition.SetBool("gunupright",false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);


            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("IdleShootReverse", false);

        }

       else if (m_isGoingRight == true && Input.GetKey(KeyCode.UpArrow) && IsGrounded() && !Input.GetKey(KeyCode.E) && pauseEverything == false || m_isGoingRight == true && Input.GetKey(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == true && Input.GetKey(KeyCode.UpArrow) && IsGrounded2() && !Input.GetKey(KeyCode.E) && pauseEverything == false || m_isGoingRight == true && Input.GetKey(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.E) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", true);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);


            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", false);
        }

        // 2. if looking right, holding down shoot and pressing Up key down
        if (m_isGoingRight == true && Input.GetKey(KeyCode.E) && Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded() && pauseEverything == false || (m_isGoingRight == true && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E) && IsGrounded() && pauseEverything == false || (m_isGoingRight == true && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == true && Input.GetKey(KeyCode.E) && Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded2() && pauseEverything == false || (m_isGoingRight == true && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E) && IsGrounded2() && pauseEverything == false || (m_isGoingRight == true && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.E) && IsGrounded2() && pauseEverything == false)))))
        {
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", true);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);


            gunposition.SetBool("GunUpRight", true);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", false); 

        }


        // 3. if looking right, holding down shoot and pressing Up key up
        if (m_isGoingRight == true && Input.GetKey(KeyCode.E) && Input.GetKeyUp(KeyCode.UpArrow) && IsGrounded() && pauseEverything == false || (m_isGoingRight == true && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == true && Input.GetKey(KeyCode.E) && Input.GetKeyUp(KeyCode.UpArrow) && IsGrounded2() && pauseEverything == false || m_isGoingRight == true && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.E) && IsGrounded2() && pauseEverything == false))
        {
            firepointposition.SetBool("gunidle", true);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);



            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("IdleShootReverse", false);

    
        }


        // 6. if looking right, pressing down Up and shoot at the same time
        if (m_isGoingRight == true && Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == true && Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E) && IsGrounded2() && pauseEverything == false)
        {

        }

        // 7. if looking right, releasing Up and shoot at the same time

        if (m_isGoingRight == true && Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == true && Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.E) && IsGrounded2() && pauseEverything == false)
        {

        }

        if (m_isGoingRight == true && Input.GetKeyUp(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == true && Input.GetKeyUp(KeyCode.E) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);



            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("IdleShootReverse", false);
        }


        if (m_isGoingRight == true && Input.GetKeyUp(KeyCode.UpArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == true && Input.GetKeyUp(KeyCode.UpArrow) && IsGrounded() && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", true);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);



            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("IdleShootReverse", false);
        }





        // if holding shoot and the up arrow is pressed when facing right

        if (Input.GetKeyDown(KeyCode.UpArrow) && PlayerRigidBody.bodyType == RigidbodyType2D.Static && IsGrounded() && m_isGoingRight == true && pauseEverything == false || Input.GetKeyDown(KeyCode.UpArrow) && PlayerRigidBody.bodyType == RigidbodyType2D.Static && IsGrounded2() && m_isGoingRight == true && pauseEverything == false)
        {
            gunposition.SetBool("GunUpRight", true);
            gunposition.SetBool("GunUpLeft", false);

            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", false);



        }

        // if holding shoot and the up arrow is released when facing right

        if (Input.GetKeyUp(KeyCode.UpArrow) && PlayerRigidBody.bodyType == RigidbodyType2D.Static && IsGrounded() && m_isGoingRight == true && pauseEverything == false || Input.GetKeyUp(KeyCode.UpArrow) && PlayerRigidBody.bodyType == RigidbodyType2D.Static && IsGrounded2() && m_isGoingRight == true && pauseEverything == false)
        {

            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("IdleShootReverse", false);

        }






































        // 1. if looking left and press shoot key down
        if (m_isGoingRight == false && Input.GetKey(KeyCode.E) && IsGrounded() && !Input.GetKey(KeyCode.UpArrow) && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.E) && !Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.E) && IsGrounded2() && !Input.GetKey(KeyCode.UpArrow) && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.E) && !Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("turnleft", true);

            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);



            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", true);

        }

        else if (m_isGoingRight == false && Input.GetKey(KeyCode.UpArrow) && IsGrounded() && !Input.GetKey(KeyCode.E) && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.UpArrow) && IsGrounded2() && !Input.GetKey(KeyCode.E) && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.E) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunupleft", true);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);



            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", true);

        }

        // 2. if looking left, holding down shoot and pressing Up key down
        if (m_isGoingRight == false && Input.GetKey(KeyCode.E) && Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.E) && Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded2() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E) && IsGrounded2() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.E) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunupleft", true);
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);




            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", true);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", false);

        }


        // 3. if looking left, holding down shoot and pressing Up key up
        if (m_isGoingRight == false && Input.GetKey(KeyCode.E) && Input.GetKeyUp(KeyCode.UpArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.E) && Input.GetKeyUp(KeyCode.UpArrow) && IsGrounded2() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.E) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("turnleft", true);
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);


            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", true);



        }


        // 6. if looking left, pressing down Up and shoot at the same time
        if (m_isGoingRight == false && Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E) && IsGrounded2() && pauseEverything == false)
        {

        }

        // 7. if looking right, releasing Up and shoot at the same time

        if (m_isGoingRight == false && Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.E) && IsGrounded2() && pauseEverything == false)
        {

        }

        if (m_isGoingRight == false && Input.GetKeyUp(KeyCode.E) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKeyUp(KeyCode.E) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", true);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);



            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", true);


        }

        if (m_isGoingRight == false && Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", true);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);



            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", true);

        }

        if (m_isGoingRight == false && Input.GetKeyUp(KeyCode.UpArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKeyUp(KeyCode.UpArrow) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", true);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);



            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", true);

        }














        // if holding shoot and aiming diagonally right (holding up and right)


        if (m_isGoingRight == true && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == true && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && IsGrounded2() && pauseEverything == false)
        {

            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", true);
            firepointposition.SetBool("cornerleft", false);


            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", true);
            gunposition.SetBool("CornerLeft", false);
        }




        if (m_isGoingRight == true && Input.GetKey(KeyCode.E) && Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == true && Input.GetKey(KeyCode.E) && Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && IsGrounded2() && pauseEverything == false)
        {

            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", true);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);


            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);
        }

        if (m_isGoingRight == true && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == true && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", true);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);

            gunposition.SetBool("GunUpRight", true);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);
        }

        if (m_isGoingRight == true && Input.GetKeyUp(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == true && Input.GetKeyUp(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", true);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);

            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);
        }

        // NOT pressing down shoot - 
        if (m_isGoingRight == true && !Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == true && !Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && IsGrounded2() && pauseEverything == false)
        {

            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", true);
            firepointposition.SetBool("cornerleft", false);

            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);
        }





        // if holding shoot and aiming diagonally left (holding up and left)


        if (m_isGoingRight == false && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", true);

            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", true);
        }




        if (m_isGoingRight == false && Input.GetKey(KeyCode.E) && Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.E) && Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", true);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);

            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", true);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);
        }

        if (m_isGoingRight == false && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("gunupleft", true);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);

            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", true);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);
        }



        if (m_isGoingRight == false && Input.GetKeyUp(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && Input.GetKeyUp(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && IsGrounded2() && pauseEverything == false)
        {
            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", true);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", false);

            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", true);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);
        }



        // NOT pressing down shoot - 
        if (m_isGoingRight == false && !Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && IsGrounded() && pauseEverything == false || m_isGoingRight == false && !Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && IsGrounded2() && pauseEverything == false)
        {

            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            firepointposition.SetBool("turnleft", false);
            firepointposition.SetBool("gunupleft", false);
            firepointposition.SetBool("turnright", false);
            firepointposition.SetBool("cornerright", false);
            firepointposition.SetBool("cornerleft", true);

            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);
        }






















































































        if (Input.GetKeyDown(KeyCode.Space) && PlayerRigidBody.bodyType == RigidbodyType2D.Static && m_isGoingRight == true && pauseEverything == false)
        {
            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);

            IsGroundedShoot = 0;
            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;
            CancelInvoke("IdleWhenShoot");


            PlayerRigidBody.velocity = new Vector2(PlayerRigidBody.velocity.x, jumpForce);
        }



        if (Input.GetKeyDown(KeyCode.Space) && PlayerRigidBody.bodyType == RigidbodyType2D.Static && m_isGoingRight == false && pauseEverything == false)
        {
            gunposition.SetBool("IdleShootReverse", true);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);

            IsGroundedShoot = 0;
            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;
            CancelInvoke("IdleWhenShoot");


            PlayerRigidBody.velocity = new Vector2(PlayerRigidBody.velocity.x, jumpForce);
        }

     
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.UpArrow) && PlayerRigidBody.bodyType == RigidbodyType2D.Static && m_isGoingRight == true && pauseEverything == false)
        {
            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);

            IsGroundedShoot = 0;
            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;
            CancelInvoke("IdleWhenShoot");


            PlayerRigidBody.velocity = new Vector2(PlayerRigidBody.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.UpArrow) && PlayerRigidBody.bodyType == RigidbodyType2D.Static && m_isGoingRight == false && pauseEverything == false)
        {
            gunposition.SetBool("IdleShootReverse", true);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);

            IsGroundedShoot = 0;
            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;
            CancelInvoke("IdleWhenShoot");


            PlayerRigidBody.velocity = new Vector2(PlayerRigidBody.velocity.x, jumpForce);
        }
















        if (Input.GetKeyUp(KeyCode.E) && IsGrounded() && m_isGoingRight == true && pauseEverything == false || Input.GetKeyUp(KeyCode.E) && IsGrounded2() && m_isGoingRight == true && pauseEverything == false)
        {
            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);

            CancelInvoke("IdleWhenShoot");
            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;

        }

        else if (Input.GetKeyUp(KeyCode.E) && !IsGrounded() && m_isGoingRight == true && pauseEverything == false || Input.GetKeyUp(KeyCode.E) && !IsGrounded2() && m_isGoingRight == true && pauseEverything == false)
        {
            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("IdleShootReverse", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);

            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;
            CancelInvoke("IdleWhenShoot");

        }


        if (Input.GetKeyUp(KeyCode.E) && IsGrounded() && m_isGoingRight == false && pauseEverything == false || Input.GetKeyUp(KeyCode.E) && IsGrounded2() && m_isGoingRight == false && pauseEverything == false)
        {
            gunposition.SetBool("IdleShootReverse", true);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);

            CancelInvoke("IdleWhenShoot");
            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;

        }

        else if (Input.GetKeyUp(KeyCode.E) && !IsGrounded() && m_isGoingRight == false && pauseEverything == false || Input.GetKeyUp(KeyCode.E) && !IsGrounded2() && m_isGoingRight == false && pauseEverything == false)
        {
            gunposition.SetBool("IdleShootReverse", true);
            gunposition.SetBool("GunUpLeft", false);
            gunposition.SetBool("GunUpRight", false);
            gunposition.SetBool("IdleShoot", false);
            gunposition.SetBool("CornerRight", false);
            gunposition.SetBool("CornerLeft", false);

            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;
            CancelInvoke("IdleWhenShoot");

        }


        // TEMPORARILY turned off jumping whilst holding Up (and also further up in code)

        if (Input.GetButtonDown("Jump") && HangCounter > 0f && !Input.GetKey(KeyCode.UpArrow) && pauseEverything == false)
        {
            PlayerRigidBody.velocity = new Vector2(PlayerRigidBody.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && PlayerRigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow) && pauseEverything == false)
        {
            PlayerRigidBody.velocity = new Vector2(PlayerRigidBody.velocity.x, PlayerRigidBody.velocity.y * .75f);
        }


        UpdateAnimationState();

        if (yourVar == true && pauseEverything == false)
        {
            PlayerRigidBody.velocity = new Vector2(0, 0);
            bulletPrefab3.enabled = false;
            bulletPrefab.enabled = false;
            bulletPrefab2.enabled = false;
        }

        if (combinedVar == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded() && pauseEverything == false || Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded2() && pauseEverything == false)
            {
                yourVar = true;
            }
        }

        if (TextBoxVanish == true)
        {
            yourVar = false;
            PlayerRigidBody.velocity = new Vector2(directionX * moveSpeed, PlayerRigidBody.velocity.y);

        }
    }

    public void UpdateAnimationState()
    {
        if (directionX == 0)
        {
            BackgroundScrollBool = false;
            BackgroundScrollBoolOpposite = false;
        }

        else if (directionX < 0 && m_isGoingRight == true && pauseEverything == false)
        {


            firepointposition.SetBool("turnleft", true);

            firepointposition.SetBool("turnright", false);

            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);

            bulletspritetransform.transform.position = originalPos;
            bulletspritetransform.transform.rotation = originalRot;

            storedDirection = -1;
            sprite.flipX = true;
            sprite2.flipX = true;

            gunposition.SetBool("IdleShootReverse", true);
            gunposition.SetBool("IdleShoot", false);
            FlipFirePoint(true);
            m_isGoingRight = false;
        }

        else if (directionX > 0 && m_isGoingRight == false && pauseEverything == false)
        {

         
            firepointposition.SetBool("turnright", true);

            firepointposition.SetBool("turnleft", false);


            firepointposition.SetBool("gunidle", false);
            firepointposition.SetBool("gunupright", false);
            bulletspritetransform.transform.position = originalPos;
            bulletspritetransform.transform.rotation = originalRot;

            storedDirection = 1;
            sprite.flipX = false;
            sprite2.flipX = false;

            gunposition.SetBool("IdleShoot", true);
            gunposition.SetBool("IdleShootReverse", false);
            FlipFirePoint(false);
            m_isGoingRight = true;
        }



        if (PlayerRigidBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        else if (PlayerRigidBody.velocity.y < -.1f)
        {
            state = MovementState.falling;

        }

        if (PlayerRigidBody.velocity.x < .1f && PlayerRigidBody.velocity.y == 0f)
        {
            state = MovementState.running;
        }

        if (PlayerRigidBody.velocity.x > .1f && PlayerRigidBody.velocity.y == 0f)
        {
            state = MovementState.running;
        }

        else if (PlayerRigidBody.velocity.x == 0)
        {
            state = MovementState.idle;
        }

        if (yourVar == true && pauseEverything == false)
        {
            state = MovementState.idle;
            sprite.flipX = false;
            sprite.flipY = false;
        }
        anim.SetInteger("state", (int)state);

        if (gameIsPaused2 == true)
        {
            pauseEverything = true;
            state = MovementState.idle;
            PlayerRigidBody.bodyType = RigidbodyType2D.Static;
            //sprite.flipX = false;
            //sprite.flipY = false;
            directionX = 0f;
            
        }
        else if (gameIsPaused2 == false)
        {
            pauseEverything = false;
            PlayerRigidBody.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void IdleWhenShoot()
    {
        PlayerRigidBody.bodyType = RigidbodyType2D.Static;
        state = MovementState.idle;
        directionX = 0;
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public bool IsGrounded2()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround2);
    }


    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "TextTest")
        {
            combinedVar = 1;
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.name == "TextTest")
        {
            combinedVar--;
            yourVar = false;
        }
    }

    public void StartCountdown()
    {
        if (LevelStart == true)
        {
            yourVar = true;
            StartCoroutine(countdownToStart());
        }
    }

    IEnumerator countdownToStart()
    {
        yield return new WaitForSeconds(1f);
        yourVar = false;

        bulletPrefab.enabled = true;
        bulletPrefab2.enabled = true;
        bulletPrefab3.enabled = true;

    }

    private void FlipFirePoint(bool isGoingRight)
    {
        Vector3 currentPosition = bulletspritetransform.position;
        if (isGoingRight)
        {


            BackgroundScrollBool = true;
            BackgroundScrollBoolOpposite = false;
            bulletspritetransform.transform.Rotate(0.0f, 180.0f, 0.0f);

            currentPosition.x += 1.9f;
        }
        else 
        {

            BackgroundScrollBool = false;
            BackgroundScrollBoolOpposite = true;
            bulletspritetransform.transform.Rotate(0.0f, 180.0f, 0.0f);

            currentPosition.x -= 1.9f;
        }
        bulletspritetransform.transform.position = currentPosition;
    }
}

