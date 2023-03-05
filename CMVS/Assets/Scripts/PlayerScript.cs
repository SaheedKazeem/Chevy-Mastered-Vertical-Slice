using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    float XInput, YInput, Speed;
    public Animator anim;
    Rigidbody2D RB;
    
    [Header("Jump")]
    [Range(1, 10)]
    public float JumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    bool isJumping, isGrounded, CanDJump, isDJumping;

    [Header("Dash")]
    public float DashSpeed; 
    public float startDashTime;
    float dashTime;
    Vector2 direction;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "TileMap")
        {
            anim.SetBool("isGrounded", true);
            isGrounded = true;
            CanDJump = true;
            anim.ResetTrigger("isDJumping");
        }

    }
    void Start()
    {

        RB = GetComponent<Rigidbody2D>();
        Speed = 200;
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        XInput = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        RB.velocity = new Vector2(XInput, RB.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        Animation();
        Movement();
    }
    #region Welcome to the Functions Room, where all the dumb code sleeps
    void Animation()
    {
        //walking animation
        anim.SetFloat("Speed", Mathf.Abs(XInput));
       
    }
    void Movement()
    {
        //Input
        XInput = Input.GetAxisRaw("Horizontal");
        YInput = Input.GetAxisRaw("Vertical");
        Jump();
        Dash();
        //Flipping Sprite

        if (XInput >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (XInput <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded == true)
            {
                RB.velocity = Vector2.up * JumpVelocity;
                isJumping = true;
                isGrounded = false;
                anim.SetBool("isGrounded", false);

            }
            else if (!isGrounded && CanDJump == true)
            {
                RB.velocity = Vector2.up * JumpVelocity;
                CanDJump = false;
                anim.SetTrigger("isDJumping");

            }
        }
        else isJumping = false;
        if (isJumping == true)
        {
            anim.SetBool("isJumping", true);
        }
        if (isJumping == false)
        {
            anim.SetBool("isJumping", false);
        }

        BetterJump();
    }
    void Dash()
    {
      
        direction = Vector2.zero;
        dashTime = startDashTime;
            if (direction == Vector2.zero)
            {
                if(Input.GetKeyDown(KeyCode.D))
                {
                    direction = Vector2.right;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    direction = Vector2.left;
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = Vector2.zero;
                    dashTime = startDashTime;
                    RB.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;

                    if (direction == Vector2.right)
                    {
                        RB.velocity = Vector2.right * DashSpeed;
                    }
                    else if (direction == Vector2.left)
                    {
                        RB.velocity = Vector2.left * DashSpeed;
                    }
                }
            }

    }
    void BetterJump()
    {
        //Adds Weight and feel to the character's Jump <<<
        if (RB.velocity.y < 0)
        {
            RB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (RB.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            RB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    #endregion
}