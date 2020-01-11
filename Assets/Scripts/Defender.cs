using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int SunCost = 100;
    [SerializeField] GameObject sun1;
    

    public int getSunCost()
    {
        return SunCost;
    }

    public void sunbacktonormal()
    {
        sun1.GetComponent<SpriteRenderer>().color = Color.white;
    }

    
}
