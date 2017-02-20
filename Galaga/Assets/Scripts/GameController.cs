using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private SpawnEnemies spawnEnemies;
    private HealthConroller healthController;
    private int roundNumber = 1;
    private WaitForSeconds startWait;
    private WaitForSeconds endWait;
    public Text message;
    public float startDelay;
    public float endDelay;

	// Use this for initializat;ion
	void Start () {
        spawnEnemies = GetComponent<SpawnEnemies>();
        healthController = GetComponent<HealthConroller>();
        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);
        StartCoroutine(GameLoop());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator GameLoop() {
        // Start off by running the 'RoundStarting' coroutine but don't return until it's finished.
        yield return StartCoroutine(WaveStarting());

        // Once the 'RoundStarting' coroutine is finished, run the 'RoundPlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(WavePlaying());

        // Once execution has returned here, run the 'RoundEnding' coroutine, again don't return until it's finished.
        
        if(!healthController.GameOver()) {
            yield return StartCoroutine(WaveEnding());
            StartCoroutine(GameLoop());
        }
        else {
            message.color = Color.red;
            message.text = "GAME OVER";
        }
    }

    private IEnumerator WaveStarting() {
        message.text = "Round " + roundNumber;
        spawnEnemies.SetMaxEnemies(5);
        yield return startWait;
    }

    private IEnumerator WavePlaying() {
        roundNumber++;
        message.text = "";
        Invoke("Spawn", 2f);
        while(!healthController.GameOver() && !spawnEnemies.ReachedMax()) {
            Debug.Log("Jessica");
            yield return null;
        }
        spawnEnemies.ResetWaveEnemies();
    }

    private IEnumerator WaveEnding() {
        yield return endWait;
    }

    void Spawn() {
        spawnEnemies.Spawn();
    }
}
