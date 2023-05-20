using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] float movementForce = 2000;
    [SerializeField] float jumpForce = 1000;
    [SerializeField] float jumpMultiplier = 100;

    public bool grounded = true;

    Rigidbody2D rbd2;

    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rbd2.AddForce(new Vector2(movementForce * Time.deltaTime ,0));
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rbd2.AddForce(new Vector2(-movementForce * Time.deltaTime ,0));
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rbd2.AddForce(new Vector2(0, 10 * jumpMultiplier * jumpForce * Time.deltaTime));
            
        }


    }
}
