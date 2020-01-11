using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
   

    int currentbuildindex;
    private void Start()
    {
        int currentbuildindex = SceneManager.GetActiveScene().buildIndex;

        if (currentbuildindex == 0)
        {
            StartCoroutine(StartScreen());
        }

        IEnumerator StartScreen()
        {
            yield return new WaitForSeconds(4.5f);
            SceneManager.LoadScene(currentbuildindex + 1);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void loadGameScreen()
    {
      var levelnumber = PlayerPrefsController.getlevel();
       
        if(levelnumber ==1 )
        {
            SceneManager.LoadScene("Level1");
        }

        if (levelnumber ==2)
        {
            SceneManager.LoadScene("Level2");
        }

        if (levelnumber ==3 )
        {
            SceneManager.LoadScene("Level3");
        }

        if (levelnumber ==4 )
        {
            SceneManager.LoadScene("Level4");
        }

        if (levelnumber ==5 )
        {
            SceneManager.LoadScene("Level5");
        }

    }
   public void QuitGame()
    {
        
        Application.Quit();
    }

    public void loadStartScreen()
    {
        
        Time.timeScale = 1;
        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("StartScreen");
    }
    public void loadStartScreenfromoptions()
    {
        
        Time.timeScale = 1;
        
        SceneManager.LoadScene("StartScreen");
    }

    public void RestartLevel()
    {
        
        Time.timeScale = 1;
        
        int currentbuildindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentbuildindex);
    }

    public void LoadNextLevel()
    {
        int currentbuildindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentbuildindex + 1);
    }

    public void LoadOptionsScreen()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene("Win Screen");
    }

    public void Loadinstructions()
    {
        SceneManager.LoadScene("Instructions1");
    }

    public void loadnextinstruction()
    {
        int currentbuildindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentbuildindex + 1);
    }
    
}
