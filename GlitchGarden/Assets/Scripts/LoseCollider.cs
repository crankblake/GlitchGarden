using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        HealthDisplay healthDisplay = FindObjectOfType<HealthDisplay>();
        healthDisplay.LoseHealth();
        Destroy(otherCollider.gameObject);
        /*
        if (healthDisplay.GetPlayerHealth() <= 0)
        {
            SceneManager.LoadScene("StartScreen");
        }*/
    }
}