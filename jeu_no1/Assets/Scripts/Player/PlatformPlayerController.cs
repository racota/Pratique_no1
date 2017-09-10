using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerController : MonoBehaviour {
    // Highly inspired by this script : https://unity3d.com/fr/learn/tutorials/topics/2d-game-creation/creating-basic-platformer-game
    private bool facingRight = true;
    [SerializeField]
    private float moveForce = 20f;
    [SerializeField]
    private float maxSpeed = 3f;
    [SerializeField]
    private Transform groundCheck;

    private Animator anim;
    private Rigidbody2D rb2d;

    // Abilities (dynamicaly changeable action control by inputs)
    Dictionary<string, Ability> currentAbilities = new Dictionary<string, Ability>();
    Dictionary<string, Ability> allAbilities = new Dictionary<string, Ability>();


    // Use this for initialization
    void Awake()
    {
        Jump jumpAbility = new Jump("jump");
        allAbilities.Add("jump", jumpAbility);
        currentAbilities.Add("jump", jumpAbility);
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Verify player's inputs by going throught all abilities.
        foreach (var ability in currentAbilities) {
            ability.Value.onUpdate(rb2d,transform,groundCheck);
        }
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

        foreach (var ability in currentAbilities)
        {
            ability.Value.onFixedUpdate(ref rb2d, transform, groundCheck);
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
