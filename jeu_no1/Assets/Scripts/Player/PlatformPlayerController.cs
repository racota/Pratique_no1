﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerController : MonoBehaviour {
    // Highly inspired by this script : https://unity3d.com/fr/learn/tutorials/topics/2d-game-creation/creating-basic-platformer-game
    private bool facingRight = true;
    private bool jump = false;
    [SerializeField]
    private float moveForce = 365f;
    [SerializeField]
    private float maxSpeed = 5f;
    [SerializeField]
    private float jumpForce = 1000f;
    [SerializeField]
    private Transform groundCheck;


    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    // Abilities (dynamicaly changeable action control by inputs)
    Dictionary<string, Ability> currentAbilities;
    Dictionary<string, Ability> allAbilities;


    // Use this for initialization
    void Awake()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
        // Verify player's inputs by going throught all abilities.

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            //anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
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
