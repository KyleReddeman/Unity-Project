using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

    public float startingHealth;
    public float health;
    private HealthConroller healthController;

	// Use this for initialization
	void Start () {
        health = startingHealth;
        healthController = GameObject.Find("GameManager").GetComponent<HealthConroller>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(float damage) {
        health -= damage;
        healthController.UpdateUI();
        if(health <= 0f && !gameObject.CompareTag("Ground")) {
            Destroy(gameObject);
        }
    }
}
