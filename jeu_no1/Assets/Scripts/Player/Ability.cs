using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Ability {

    private string id;

    public Ability(string newId = "") {
        id = newId;
    }

    public abstract void onUpdate(Rigidbody2D rb2d, Transform player, Transform groundCheck);
    public abstract void onFixedUpdate(ref Rigidbody2D rb2d, Transform player, Transform groundCheck);

    public string Id {
        get {
            return id;
        }
    }
}
