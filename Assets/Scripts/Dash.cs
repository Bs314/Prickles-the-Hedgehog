using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashTime = 0.5f;
    private float dashTimeLeft;
    public bool isDashing = false;
    private float dashDirection;
    public Rigidbody2D rb;

    private float gravityScale;

    void Start()
    {
        
        dashTimeLeft = dashTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isDashing)
        {
            isDashing = true;
            gravityScale = rb.gravityScale;
            rb.gravityScale = 0;
            dashDirection = transform.localScale.x;
            rb.velocity = new Vector2(( dashDirection * dashDistance ) / dashTime , 0);
        }

        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                dashTimeLeft -= Time.deltaTime;
                
            }
            else
            {
                rb.gravityScale = gravityScale;
                isDashing = false;
                dashTimeLeft = dashTime;
                rb.velocity = Vector2.zero;
            }
        }
    }

}
