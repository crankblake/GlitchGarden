using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        //This is with a TAG
        /*
        if (otherObject.GetComponent<Defender>() && otherObject.tag == "Gravestone")
        {
            GetComponent<Attacker>().Jump();
        }*/
        if (otherObject.GetComponent<Defender>() && otherObject.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (otherObject.GetComponent<Defender>())
        {
            Debug.Log("Trying to Attack with Fox: " + otherObject);
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
