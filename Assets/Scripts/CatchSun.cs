using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchSun : MonoBehaviour
{
    SunDisplay sunDisplay;
      
    int sunamount = 50;

    private void OnMouseDown()
    {
        sunDisplay = FindObjectOfType<SunDisplay>();
        sunDisplay.AddSuns(sunamount);
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
    }

    


}
