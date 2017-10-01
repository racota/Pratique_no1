using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Ability {
    private bool grounded = false;

    private bool jump = false;

    private float jumpForce = 200f;

    public Jump(string id): base(id) {
        
    }

    public override void onFixedUpdate(ref Rigidbody2D rb2d, Transform player, Transform groundCheck)
    {
        if (jump)
        {
            //anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    public override void onUpdate(Rigidbody2D rb2d, Transform player, Transform groundCheck)
    {
        grounded = Physics2D.Linecast(player.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }
}
