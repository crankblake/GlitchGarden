using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthDisplay : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;
    [SerializeField] float damageHealth = 10f;
    Text healthText;

    private void Start()
    {
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

