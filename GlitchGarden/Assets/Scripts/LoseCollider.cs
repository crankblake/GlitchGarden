using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthDisplay healthDisplay = FindObjectOfType<HealthDisplay>();
        healthDisplay.LoseHealth();
        /*
        if (healthDisplay.GetPlayerHealth() <= 0)
        {
            SceneManager.LoadScene("StartScreen");
        }*/
    }
}