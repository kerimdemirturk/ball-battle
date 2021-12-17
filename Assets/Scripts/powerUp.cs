using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public float turnSpeed;
    public GameObject player;
    

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,1,0 *turnSpeed);
    }
    
}
