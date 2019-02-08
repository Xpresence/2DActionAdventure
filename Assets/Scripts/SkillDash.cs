using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDash : MonoBehaviour {


    public float dashSpeed = 50f;

    bool dash = false;

    private Rigidbody2D rb;
    //CharacterController CC;


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        //CC = GetComponent<CharacterController>();
	}

    void Update()
    {
        if (Input.GetButtonDown("Dash"))
        {
            dash = true;
        }
    }

        // Update is called once per frame
    void FixedUpdate()
    {
        
        if (dash)
        {

            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * dashSpeed, GetComponent<Rigidbody2D>().velocity.y);
            rb.AddForce(new Vector2(dashSpeed, 0f));
            //dashSpeed = 20f;
            dash = false;
        }

    }
}
