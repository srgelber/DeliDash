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

    private bool facingRight = true;

    public GameObject leftLight;
    public GameObject rightLight;

    private SpriteRenderer sr;

    private CapsuleCollider cap;

    private AudioSource jumpSound;

    float doubleTap;
    KeyCode lastCode;
    public float dashSpeed;
    private float dashCount;
    public float startDashCount;
    private int side;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cap = GetComponent<CapsuleCollider>();
        jumpSound = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();

        dashCount = startDashCount;
    }

    private void FixedUpdate() {
        Move = Input.GetAxis("Horizontal");

        if(rb.velocity.magnitude > 0.2){
            anim.SetBool("isMoving", true);
        }else{
            anim.SetBool("isMoving", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed*Move,rb.velocity.y);


        if(Input.GetButtonDown("Jump") && jumpCount < 2){
            anim.SetTrigger("isJumping");
            jumpSound.Play();
            rb.AddForce(new Vector2(rb.velocity.x,jump));
            jumpCount++;
            
        }

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

        if (side == 0)
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
        }
        else
        {
            if (dashCount <= 0)
            {
                side = 0;
                dashCount = startDashCount;
                rb.velocity = Vector2.zero;
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
            }
            
        }
    }

    private void OnCollisionEnter(Collision other) {
        jumpCount = 0;
        
    }
}
