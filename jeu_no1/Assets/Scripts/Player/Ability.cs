using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Ability : MonoBehaviour {

    private string id;

    public Ability(string newId = "") {
        id = newId;
    }

    public abstract void onUpdate();
    public abstract void onFixedUpdate();

    public string Id {
        get {
            return id;
        }
    }
}
