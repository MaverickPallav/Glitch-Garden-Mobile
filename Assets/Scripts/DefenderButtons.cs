using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButtons : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void Start()
    {
        LabelbuttonWithCost();
    }

    private void LabelbuttonWithCost()
    {
        Text costtext = GetComponentInChildren<Text>();
        if (!costtext)
        {
            //Debug.LogError(name + "has no cost text , add some");
        }
        else
        {
            costtext.text = defenderPrefab.getSunCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButtons>();

        foreach (DefenderButtons button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(84, 84, 84, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().setSelectedDefender(defenderPrefab);

       
    }

    
}
