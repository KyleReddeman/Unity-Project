using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

    private bool fired = false;
    public GameObject projectile;
    public Transform bulletSpawnPosition;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float input = Input.GetAxis("Fire1");
        if(input > .2f && !fired) {
            fired = true;
            Instantiate(projectile, bulletSpawnPosition.position, Quaternion.identity);
            Invoke("CanFire", .3f);
        }
	}

    void CanFire() {
        fired = false;
    }
}
