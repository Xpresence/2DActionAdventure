using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGrab : MonoBehaviour {

    private CharacterController CC;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        CC = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Grab") && CC.grounded)
        {
            CC.Skills.Grab.IsPressed = true;
        }

        if (Input.GetButtonUp("Grab"))
        {
            CC.Skills.Grab.IsPressed = false;
        }

    }

    void FixedUpdate()
    {
        if (CC.Skills.Grab.IsPressed)
        {
            // перетаскиваем объект за игроком

        }

    }

    void OnTriggerEnter(Collider2D collider)
    {
        // проверяем способность перетаскивания
    }
}
