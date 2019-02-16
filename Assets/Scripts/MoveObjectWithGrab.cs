using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectWithGrab : MonoBehaviour {

    private GameObject player;
    private CharacterController CC;

    private Rigidbody2D rb;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        CC = player.GetComponent<CharacterController>();
    }

    void Start()
    {
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

    }

    void OnTriggerStay2D(Collider2D collider)
    {
        //Debug.Log(CC.Skills.Grab.IsPressed);
        // проверяем способность перетаскивания
        // перетаскиваем объект за игроком
        if (CC.Skills.Grab.IsPressed)
        {
            //collider.attachedRigidbody.AddForce(collider.attachedRigidbody.velocity);
        }
    }
}
