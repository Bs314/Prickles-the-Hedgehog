using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    

    public bool isGrounded;
    public float speed;
    public float jumpForce;
    private float moveInput;

    public Transform feetPos;
    private Rigidbody2D rb2d;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    public int doubleJump = 2;
    private int doubleJumpCounter;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public Dash dash;
    public bool dashAbility;

    public ThrowThorn throwThorn;
    public bool throwThornAbility;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dash.enabled = false;
    }


    private void FixedUpdate() 
    {
        if(dashAbility)
        {
            if(dash.isDashing)
            {

            }
            else
            {
                moveInput = Input.GetAxis("Horizontal");
                rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
            }
        }
        else
        {
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
        }
           

        Flip();    
    }

    private void Update()
    {
        Jump();

        if(dashAbility)
        {
            dash.enabled = true;
        }
        else
        {
            dash.enabled =false;
        }

        if(throwThornAbility)
        {
            throwThorn.enabled = true;
        }
        else
        {
            throwThorn.enabled =false;
        }

    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded)
        {
            doubleJumpCounter = doubleJump;
        }

        if ((isGrounded == true || doubleJumpCounter > 0) && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2d.velocity = Vector2.up * jumpForce;
            doubleJumpCounter--;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb2d.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void Flip()
    {

        float direction = Input.GetAxisRaw("Horizontal");

        if(direction > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if(direction < 0)
        {
            transform.localScale = new Vector3(-1,1,1);  
        }
        else{}
    }

    public float GetPlayersDirection()
    {
        float direction = transform.localScale.x;
        return direction;
    }


      
       
}
