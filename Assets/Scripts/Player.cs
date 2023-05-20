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

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate() 
    {
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);   

        Flip();    
    }

    private void Update() {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if( isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2d.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                 rb2d.velocity = Vector2.up * jumpForce;
                 jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void Flip()
    {
        if(rb2d.velocity.x>0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if(rb2d.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);  
        }
        else{}
    }


      
       
}
