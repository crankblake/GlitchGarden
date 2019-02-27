using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    float maxDamage;
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        HealthDisplay healthDisplay = FindObjectOfType<HealthDisplay>();
        healthDisplay.LoseHealth();
        //otherCollider.gameObject.GetComponent<Health>().DealDamage(maxDamage);
        //FindObjectOfType<Health>().DealDamage(maxDamage);
        Destroy(otherCollider.gameObject);
        /*
        if (healthDisplay.GetPlayerHealth() <= 0)
        {
            SceneManager.LoadScene("StartScreen");
        }*/
    }
}