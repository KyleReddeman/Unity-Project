using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {

    public Transform bulletSpawn;
    public GameObject bullet;
    public AudioSource audio;
    public float fireDelay = 1f;
    private bool canFire = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(canFire) {
            canFire = false;
            audio.Play();
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            Invoke("Fire", fireDelay);
        }
	}

    void Fire() {
        canFire = true;
    }
}
