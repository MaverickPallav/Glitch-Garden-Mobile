using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] int NumberOfAttackers = 0;
    bool LevelTimerFinished = false;
    [SerializeField] GameObject WinLabel;
    [SerializeField] AudioClip WinSound;
    [SerializeField] float WinSoundDuration = 1f;
    [SerializeField] GameObject LoseLabel;
    [SerializeField] AudioClip LoseSound;
    [SerializeField] GameObject PauseLabel;
    [SerializeField] AudioClip PauseSound;

    MusicPlayer musicplayer;

    private void Start()
    {
        WinLabel.SetActive(false);
        LoseLabel.SetActive(false);
        PauseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        NumberOfAttackers++;
    }

    public void AttackerKilled()
    {
        NumberOfAttackers--;

        if(NumberOfAttackers == 0 && LevelTimerFinished)
        {
            Debug.Log("Level has finished");
            StartCoroutine(HandleWinCondition());
            
        }
    }

    IEnumerator HandleWinCondition()

    { 
        WinLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(WinSound, Camera.main.transform.position, 0.8f);
        yield return new WaitForSeconds(WinSoundDuration);
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            FindObjectOfType<LevelLoader>().LoadWinScreen();
        }
        else
        {
            FindObjectOfType<LevelLoader>().LoadNextLevel();
        }

    }

    public void levelTimerFinished()
    {
        LevelTimerFinished = true;
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();

        foreach(EnemySpawner spawner in spawners)
        {
            spawner.StopSpawing();
        }

        EnemySpawnerEasy[] spawnerseasy = FindObjectsOfType<EnemySpawnerEasy>();

        foreach(EnemySpawnerEasy spawner in spawnerseasy)
        {
            spawner.StopSpawing();
        }
    }

    public void LoseScreen()
    {
        musicplayer = FindObjectOfType<MusicPlayer>();
        musicplayer.GetComponent<AudioSource>().Stop();
        LoseLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(LoseSound, Camera.main.transform.position, 0.8f);
        
    }

    public void PauseScreen()
    {
        PauseLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(PauseSound, Camera.main.transform.position, 0.02f);       
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PauseLabel.SetActive(false);
        Time.timeScale = 1;
        AudioSource.PlayClipAtPoint(PauseSound, Camera.main.transform.position, 0.02f);
    }
}
