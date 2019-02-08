using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterController : MonoBehaviour {

    public bool grounded = false;
    public Transform groundCheck;

    public bool facingRight = true;

    public float maxSpeed = 5f;
    public float move;


    // Jump
    public float jumpForce = 500f;
    public bool jump = false;

    // Dash
    public float dashSpeed = 50f;
    bool dash = false;




    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = .05f;

    private Rigidbody2D rb;

    Vector3 targetVelocity;

    //float timer = 0.0f;

    // Use this for initialization
    void Start ()
    {
        //Dash = GetComponent<SkillDash>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1<<LayerMask.NameToLayer("Ground"));

        //if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && grounded)
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        if (Input.GetButtonDown("Dash"))
        {
            dash = true;
        }

        move = Input.GetAxis("Horizontal");

        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        /*timer += Time.deltaTime;
        int seconds = Convert.ToInt32(timer % 60);
        Debug.Log(Time.time);*/
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }


        if (jump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

        if (dash)
        {
            targetVelocity = facingRight ? new Vector2(dashSpeed, 0f) : new Vector2(-dashSpeed, 0f);
            /*if (facingRight)
            {
                targetVelocity = new Vector2(dashSpeed, 0f);
            }
            else
            {
                targetVelocity = new Vector2(-dashSpeed, 0f);
            }*/

            dash = false;

        }
        else
        {
            targetVelocity = new Vector2(move * maxSpeed, rb.velocity.y);
        }


        //GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);


        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);






        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.R))
        {  
            Application.LoadLevel(Application.loadedLevel);
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
