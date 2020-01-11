using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultDifficulty : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefsController.SetDifficultyLevel(1);
        PlayerPrefsController.setlevel(1);
        PlayerPrefsController.SetMasterVolume(0.015f);
    }
}
