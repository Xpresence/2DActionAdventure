using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFlow : MonoBehaviour {

    public float flowForce = 3f;
   // public bool grounded = false;
    public bool flow = false;
   // public Transform groundCheck;
    CharacterController CC;

    // Use this for initialization
    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void Update()
    {
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        //if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && grounded)
        if (Input.GetButtonDown("Flow") && CC.grounded)
        {
            flow = true;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flow && CC.facingRight)
        {
            transform.position += new Vector3(flowForce, 0f, 0f);
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, flowForce));
            //transform.position.x  += flowForce;
            flow = false;
        }
        else if (flow && !CC.facingRight)
        {
            transform.position -= new Vector3(flowForce, 0f, 0f);
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, flowForce));
            //transform.position.x  += flowForce;
            flow = false;
        }

    }

}
