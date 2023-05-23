using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    Player player;
    BoxCollider2D box;
    Rigidbody2D rb;
    public float throwSpeed;
    public bool isItTouch;
    float direction;

    public float deathTime ;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        isItTouch = false;
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        
        direction = player.GetPlayersDirection();
        rb.velocity = new Vector2 (throwSpeed * direction, 0);
        Invoke("ChangeTriggerState",0.01f);
        
    }

    // Update is called once per frame
    void Update()
    {
        deathTime -= Time.deltaTime;

        if(deathTime < 0)
        {
            Destroy(gameObject,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground")
        {
            rb.velocity = Vector2.zero;
            
            rb.bodyType = RigidbodyType2D.Static;
            deathTime = 6;
            Destroy(gameObject, 5f);
        } 
    }

    void ChangeTriggerState()
    {
        box.isTrigger = false;
    }

    


}
