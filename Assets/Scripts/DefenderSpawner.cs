using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
     Defender defender;
    const string DEFENDER_PARENT_NAME = "Defenders";
    GameObject defenderparent;

    private void Start()
    {
        
        CreateParentDefender();
    }

    private void CreateParentDefender()
    {
        defenderparent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderparent)
        {
            defenderparent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        
        AttemptToPlaceDefenderAt(getsquareclicked());
    }

    public void setSelectedDefender(Defender defendertoselect)
    {
        defender = defendertoselect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var sundisplay = FindObjectOfType<SunDisplay>();
        int defenderCost = defender.getSunCost();
        if(sundisplay.haveEnoughSuns(defenderCost))
        {
                spawnDefender(gridPos);
                sundisplay.SpendingSuns(defenderCost);
        }
    }

    private Vector2 getsquareclicked()
    {
        Vector2 clickpos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldpos = Camera.main.ScreenToWorldPoint(clickpos);
        Vector2 gridpos = snaptogrid(worldpos);
        return gridpos;
    }

    private Vector2 snaptogrid(Vector2 rawworldpos)
    {
        float newX = Mathf.RoundToInt(rawworldpos.x);
        float newY = Mathf.RoundToInt(rawworldpos.y);
        return new Vector2(newX, newY);
    }

    void spawnDefender(Vector2 newWorldPos)
    {
       Defender newdefender = Instantiate(defender,newWorldPos , transform.rotation) as Defender;
        newdefender.transform.parent = defenderparent.transform;
        
    }
}
