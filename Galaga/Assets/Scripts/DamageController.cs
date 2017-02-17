using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

    public float startingHealth;
    public float health;

	// Use this for initialization
	void Start () {
        health = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(float damage) {
        health -= damage;
        if(health <= 0f) {
            Destroy(gameObject);
        }
    }
}
