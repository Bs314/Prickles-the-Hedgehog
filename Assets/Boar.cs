using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour
{

    public LayerMask playerLayer; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(new Vector2(transform.position.x + 1.6f, transform.position.y), Vector2.right, 7f, playerLayer);
        
        if(hit2D.collider != null) 
        {
            Debug.Log("I see something" + hit2D.transform.name);
            if(hit2D.transform.tag == "Player")
            {
                Debug.Log("I see the player");
            }
        }
    }
}
