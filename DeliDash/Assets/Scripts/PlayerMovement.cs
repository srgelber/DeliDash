using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    private float Move;
    private Animator anim;
    public Rigidbody rb;

    private int jumpCount = 2;

    [SerializeField] private int maxJump = 1;

    private int numDashes = 1;

    public isGrounded iG;
    private bool facingRight = true;

    public GameObject leftLight;
    public GameObject rightLight;

    public BoxCollider box;
    private SpriteRenderer sr;

    private CapsuleCollider cap;

    private AudioSource jumpSound;

    public wallstick ws;

    float doubleTap;
    KeyCode lastCode;
    public float dashSpeed;
    private float dashCount;
    public float startDashCount;
    private int side;
    private Vector2 gravity = Physics.gravity;

    [SerializeField] private bool hasCheese = false;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cap = GetComponent<CapsuleCollider>();
        //box = GetComponent<BoxCollider>();
        jumpSound = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        dashCount = startDashCount;
    }

   

    private void FixedUpdate() {
        Move = Input.GetAxis("Horizontal");

        if(rb.velocity.magnitude > 1){
            anim.SetBool("isMoving", true);
        }else{
            anim.SetBool("isMoving", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //add cheese check here
        if(ws.touchingWall == false || hasCheese){
            Move = Input.GetAxis("Horizontal");
        }

        //add cheese check here
        if(ws.touchingWall == false || hasCheese){
            rb.velocity = new Vector2(speed*Move,rb.velocity.y);
        }

        if(iG.playerGrounded == true){
            ws.touchingWall = false;
            jumpCount = 0;
            numDashes = 0;
        }


        if(Input.GetButtonDown("Jump") && jumpCount < maxJump){
            anim.SetTrigger("isJumping");
            rb.velocity = new Vector2(rb.velocity.x, 0);
            jumpSound.Play();
            rb.AddForce(new Vector2(rb.velocity.x,jump));
            jumpCount++;
            
        }

        /*if (Input.GetButton("Jump") && jumpCount >= 2)
        {
            Physics2D.gravity = Vector2.zero;
            
            if (Input.GetButtonUp("Jump"))
            {
                Physics2D.gravity = gravity;
            }
        }*/

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (facingRight)
            {
                
                facingRight = false;
                sr.flipX = true;
                //transform.Rotate(0f, 180f, 0f);
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (!facingRight)
            {
                
                //transform.Rotate(0f, -180f, 0f);
                sr.flipX = false;
                facingRight = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){
            anim.SetBool("isDucking", true);
            //cap.height = 0.2f;
            
            
        }else if(Input.GetKeyUp(KeyCode.DownArrow)){
            anim.SetBool("isDucking", false);
            
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (side == 0 && numDashes == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (doubleTap > Time.time && (lastCode == KeyCode.LeftArrow || lastCode == KeyCode.A))
                {
                    side = 1;
                }
                else
                {
                    doubleTap = Time.time + 0.5f;
                }

                lastCode = KeyCode.A;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (doubleTap > Time.time && (lastCode == KeyCode.RightArrow || lastCode == KeyCode.D))
                {
                    side = -1;
                }
                else
                {
                    doubleTap = Time.time + 0.5f;
                }

                lastCode = KeyCode.D;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (facingRight)
                {
                    side = -1;
                }

                else
                {
                    side = 1;
                }
            }
        }
        else
        {
            if (dashCount <= 0)
            {
                side = 0;
                dashCount = startDashCount;
                //rb.velocity = Vector2.zero;
            }
            else
            {
                dashCount -= Time.deltaTime;

                if(side == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (side == -1)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
                numDashes++;
            }
            
        }
    }

    private void OnCollisionEnter(Collision other) {

        if(other.collider.gameObject.tag != "Player" && hasCheese){
            jumpCount = 0;

            numDashes = 0;
        }
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Butter")
        {
            startDashCount = 0.2f;
            dashSpeed = 25;
        }

        else if (other.tag == "Chicken")
        {
            maxJump = 2;
        }

        else if (other.tag == "Cheese")
        {
            hasCheese = true;
        }

        else if (other.tag == "Enemy")
        {
            rb.velocity = Vector2.zero;
            if (facingRight)
            {
                rb.velocity = Vector2.left * speed;
                rb.velocity = new Vector2(0, 5);
            }

            else
            {
                rb.velocity = Vector2.right * speed;
                rb.velocity = new Vector2(0, 5);
            }
            
        }
    }
}
