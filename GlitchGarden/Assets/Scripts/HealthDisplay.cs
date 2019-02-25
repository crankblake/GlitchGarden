using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] float baseHealth = 3f;
    [SerializeField] float damageHealth = 1f;
    float playerHealth;
    Text healthText;
    PlayerPrefsController playerPrefs;

    private void Start()
    {
        playerHealth = baseHealth - PlayerPrefsController.GetDifficultyLevel();
        /*
        float difficulty = PlayerPrefsController.GetDifficultyLevel();
        playerHealth = playerHealth * (1 - difficulty);
        playerHealth = Mathf.Round(playerHealth);
        */
        healthText = GetComponent<Text>();
        UpdateDisplay();
        
    }

    private void UpdateDisplay()
    {
        healthText.text = playerHealth.ToString();
    }

    public void LoseHealth()
    {
        if (playerHealth >= damageHealth)
        {
            playerHealth -= damageHealth;
            UpdateDisplay();
        }
        if (playerHealth <= 0)
        {
            //FindObjectOfType<LevelController>().StartCoroutine("HandleLoseCondition");
            FindObjectOfType<LevelController>().PlayerHealthIsZero();
        }
    }
    public float GetPlayerHealth()
    {
        return playerHealth;
    }
}

