using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//using Player;


public class CharacterController : MonoBehaviour {

    public bool grounded = false;
    public Transform groundCheck;

    public bool facingRight = true;

    public float maxSpeed = 5f;
    public float move;

    // Skills
    private Player.Skills Skills;

    // Cooldown
    private Cooldown Cooldown;


    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = .05f;

    private Rigidbody2D rb;

    private Vector3 targetVelocity;

    // Use this for initialization
    void Awake ()
    {
        Skills = new Player.Skills();
        Cooldown = new Cooldown();
    }

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update ()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1<<LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Skills.Jump.IsPressed = Skills.Jump.CanRunSkill();
        }

        if (Input.GetButtonDown("Dash"))
        {
            Skills.Dash.IsPressed = Skills.Dash.CanRunSkill();
        }

        move = Input.GetAxis("Horizontal");

        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }


        if (Skills.Jump.IsPressed)
        {

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Skills.Jump.Parameter));
            Skills.Jump.IsPressed = false;
            
        }

        if (Skills.Dash.IsPressed)
        {

            targetVelocity = facingRight ? new Vector2(Skills.Dash.Parameter, 0f) : new Vector2(-Skills.Dash.Parameter, 0f);
            Skills.Dash.IsPressed = false;

            StartCoroutine(Cooldown.CoroutineCooldown(5f, (x) => { Skills.Dash.IsCooldown = x; }));
        }
        else
        {
            targetVelocity = new Vector2(move * maxSpeed, rb.velocity.y);
        }


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
