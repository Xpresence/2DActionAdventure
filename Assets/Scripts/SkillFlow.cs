using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFlow : MonoBehaviour {

    private CharacterController CC;

    // Use this for initialization
    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Flow") && CC.grounded)
        {
            CC.Skills.Flow.IsPressed = CC.Skills.Flow.CanRunSkill();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CC.Skills.Flow.IsPressed && CC.facingRight)
        {
            transform.position += new Vector3(CC.Skills.Flow.Parameter, 0f, 0f);

            CC.Skills.Flow.IsPressed = false;
        }
        else if (CC.Skills.Flow.IsPressed && !CC.facingRight)
        {
            transform.position -= new Vector3(CC.Skills.Flow.Parameter, 0f, 0f);

            CC.Skills.Flow.IsPressed = false;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
