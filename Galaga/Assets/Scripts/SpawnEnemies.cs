using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public Camera camera;
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 5f;
    public GameObject enemy1;
    private Transform[] spawnPoints = new Transform[5];
	// Use this for initialization
	void Start () {
		for(int i = 0; i < spawnPoints.Length; i++) {
            Transform transform = new GameObject().transform;
            transform.position = camera.ViewportToWorldPoint(new Vector3(.2f * i + .1f, 1f, 10f));
            spawnPoints[i] = transform;
        }
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("Spawn", spawnTime);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void Spawn() {
        int spawnPoint = Random.Range(0, 5);
        Instantiate(enemy1, spawnPoints[spawnPoint].position, Quaternion.identity);
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("Spawn", spawnTime);
    }
}
