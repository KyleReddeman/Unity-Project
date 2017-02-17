using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthConroller : MonoBehaviour {
    public Slider playerSlider;
    public Slider groundSlider;
    public GameObject player;
    public GameObject ground;
    public Color fullHealthColor = Color.green;
    public Color noHealthColor = Color.red;
    public Image playerFillImage;
    public Image groundFillImage;

    private DamageController playerDamageController;
    private DamageController groundDamageController;

	// Use this for initialization
	void Start () {
        playerDamageController = player.GetComponent<DamageController>();
        groundDamageController = ground.GetComponent<DamageController>();

        playerSlider.maxValue = playerDamageController.startingHealth;
        groundSlider.maxValue = groundDamageController.startingHealth;

	}
	
	// Update is called once per frame
	void Update () {
        UpdateUI();
	}

    void UpdateUI() {
        playerSlider.value = playerDamageController.health;
        groundSlider.value = groundDamageController.health;

        playerFillImage.color = Color.Lerp(noHealthColor, fullHealthColor, playerDamageController.health / playerDamageController.startingHealth);
        groundFillImage.color = Color.Lerp(noHealthColor, fullHealthColor, groundDamageController.health / groundDamageController.startingHealth);
    }
}
