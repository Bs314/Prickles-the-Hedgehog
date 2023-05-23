using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bees : MonoBehaviour
{

    public Transform pos1;
    public Transform pos2;
    
    
    Vector3 originalPosition;
    Vector3 target;
    Vector3 target1;
    Vector3 target2;
    Vector3 target3;
    public bool isInRange;
    float speed;
    public float travelSpeed;
    public float followSpeed;
    public float returnSpeed;
    float randomX;
    float randomY;

    void Start()
    {
        
        target1 = transform.position;
        target2 = pos1.position;
        target3 = pos2.position;
        target = pos1.position;
        speed = travelSpeed;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, followSpeed * Time.deltaTime);       
            
        }
        else
        {
            TravelArround();
        }

    }

    private void TravelArround()
    {
        if(transform.position != target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            if(target == target1)
            {
                speed =travelSpeed;
                target = target2;
            }
            else if(target == target2)
            {
                target = target3;
            }
            else
            {
                target = target1;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Player")
        {
            isInRange = true;    
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if(other.tag == "Player")
        {
            isInRange = false;   
            target = target1; 
            speed = returnSpeed;;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player")
        {
            Debug.DrawLine(transform.position,other.transform.position,Color.red);
            target = other.transform.position;
        }
    }
    
}