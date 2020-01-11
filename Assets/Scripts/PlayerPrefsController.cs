using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    // const used because we want to remain constant throught the whole game
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level";

    const float MAX_VOLUME = 1f;
    const float MIN_VOLUME = 0f;

    const float MAX_DIFFICULTY = 3f;
    const float MIN_DIFFICULTY = 1f;

    const float MAX_LEVEL= 5f;
    const float MIN_LEVEL = 1f;


    // static is used because we dont want any script to change this function value
    public static void SetMasterVolume(float volume)
    {
        if (volume <= MAX_VOLUME && volume >= MIN_VOLUME)
        {
            Debug.Log("master volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);  
        }
        else
        {
            Debug.LogError("master volume invalid");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficultyLevel(float difficultyNumber)
    {
        if (difficultyNumber <= MAX_DIFFICULTY && difficultyNumber >= MIN_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficultyNumber);
            Debug.Log("difficulty set to" + difficultyNumber);
        }
        else
        {
            Debug.LogError("invalid Difficulty Level");
        }
    }

    public static float GetDifficultyLevel()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void setlevel(float levelnumber)
    {
        if(levelnumber >= MIN_LEVEL && levelnumber <= MAX_LEVEL)
        {
            PlayerPrefs.SetFloat(LEVEL_KEY, levelnumber);
        }
        else
        {
            Debug.LogError("invalid level number");
        }
    }

    public static float getlevel()
    {
        return PlayerPrefs.GetFloat(LEVEL_KEY);
    }
}
