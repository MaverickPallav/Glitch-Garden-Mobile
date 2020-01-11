using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SunDisplay : MonoBehaviour
{
    [SerializeField] int suns = 50;
    Text SunText;

    private void Start()
    {
        SunText = GetComponent<Text>();
        updateDisplay();
    }

    private void updateDisplay()
    {
        SunText.text = "Sun: " + suns.ToString();
    }

    public bool haveEnoughSuns(int amount)
    {
        return suns >= amount;
    }

    public void AddSuns(int amount)
    {
        suns += amount;
        updateDisplay();
    }

    public void SpendingSuns(int spend)
    {
        if (suns >= spend)
        {
            suns -= spend;
            updateDisplay();
        }
    }
}
