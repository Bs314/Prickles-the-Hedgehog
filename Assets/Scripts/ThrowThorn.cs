using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowThorn : MonoBehaviour
{

    public GameObject thorn;
    public Transform throwPosition;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(thorn, throwPosition.position, Quaternion.identity);
        }
    }
}
