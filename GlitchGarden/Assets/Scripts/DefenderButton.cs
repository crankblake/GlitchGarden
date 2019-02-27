using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    //[SerializeField] Color onColor;
    [SerializeField] Color offColor;
    [SerializeField] Defender defenderPrefab;

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogError(name + " has no cost text, add some!");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log("Mouse was clicked");

        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(47, 47, 47, 255);
        }
        //SpriteRenderer renderer= gameObject.GetComponent<SpriteRenderer>();
        GetComponent<SpriteRenderer>().color = Color.white;
        //renderer.color = onColor;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
    /*
    private void OnMouseUp()
    {
        Debug.Log("Mouse is no longer clicked");
        //var spriteRenderer = gameObject.GetComponent<Renderer>();
        //SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        GetComponent<SpriteRenderer>().color = offColor;
        //renderer.color = offColor;
    }*/
}
