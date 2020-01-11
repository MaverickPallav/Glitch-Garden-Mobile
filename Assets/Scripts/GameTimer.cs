using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our Level Timer in seconds")]
    public float LevelTime = 10;
    bool TriggeredLevelFinish = false; // bool created so that we can get out of the update function without getting stuck in looping

    private void Start()
    {
        var difficultyLevel = PlayerPrefsController.GetDifficultyLevel();
        var levelnumber = PlayerPrefsController.getlevel();

        if (levelnumber == 1 || levelnumber == 2 )
        {
            if (difficultyLevel == 1){ LevelTime = 40f;}
            if (difficultyLevel == 2){ LevelTime = 50f;}
            if (difficultyLevel == 3){ LevelTime = 60f;}
        }
        if (levelnumber == 3 || levelnumber == 4 || levelnumber == 5)
        {
            if (difficultyLevel == 1) { LevelTime = 100f; }
            if (difficultyLevel == 2) { LevelTime = 110f; }
            if (difficultyLevel == 3) { LevelTime = 120f; }
        }


    }
    // Update is called once per frame
    void Update()
    {
        if(TriggeredLevelFinish) { return; }

       
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / LevelTime;

        bool TimerFinished = (Time.timeSinceLevelLoad >= LevelTime);

        if(TimerFinished)
        {
            TriggeredLevelFinish = true;
            FindObjectOfType<LevelController>().levelTimerFinished();
        }
    }
}
