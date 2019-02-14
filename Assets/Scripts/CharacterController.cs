using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

using PlayerNamespace;
using CooldownNamespace;

public class CharacterController : MonoBehaviour {

    public bool grounded = false;
    public Transform groundCheck;

    public bool facingRight = true;

    public float maxSpeed = 5f;
    public float move;

    // Skills
    public Skills Skills;

    // Cooldown
    private Cooldown Cooldown;


    private Rigidbody2D rb;


    private Vector3 zeroVelocity = Vector3.zero;
    private float movementSmoothing = 0.05f;

    private Vector3 targetVelocity;

    // Use this for initialization
    void Awake ()
    {
        Skills = new Skills();
        Cooldown = new Cooldown();
    }

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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

        /*if (Input.GetButtonDown("Grab") && grounded)
        {
            Skills.Grab.IsPressed = true;
        }*/

        move = Input.GetAxis("Horizontal");
  
    }
 
    void FixedUpdate ()
    {

        if (move > 0 && !facingRight)
        {
            FlipSprite();
        }
        else if (move < 0 && facingRight)
        {
            FlipSprite();
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

            StartCoroutine(Cooldown.CoroutineCooldown(Skills.Dash.Cooldown, (x) => { Skills.Dash.IsCooldown = x; }));
        }
        else
        {
            targetVelocity = new Vector2(move * maxSpeed, rb.velocity.y);
        }


        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref zeroVelocity, movementSmoothing);





        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.R))
        {
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }*/

    void FlipSprite()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
