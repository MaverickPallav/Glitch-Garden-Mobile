using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    [SerializeField] Slider DifficultySlider;
    [SerializeField] float DefaultDifficulty = 1f;

    [SerializeField] Slider LevelSlider;
    [SerializeField] float DefaultLevel = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        VolumeSlider.value = PlayerPrefsController.GetMasterVolume();
        DifficultySlider.value = PlayerPrefsController.GetDifficultyLevel();
        LevelSlider.value = PlayerPrefsController.getlevel();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
        {
            musicPlayer.SetVolume(VolumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music Player found.... did you start from splash screen ");
        }

        
        
    }

    public void SaveandExit()
    {
        PlayerPrefsController.SetDifficultyLevel(DifficultySlider.value);
        PlayerPrefsController.setlevel(LevelSlider.value);
        PlayerPrefsController.SetMasterVolume(VolumeSlider.value);
        FindObjectOfType<LevelLoader>().loadStartScreenfromoptions();
    }

    public void backtodefault()
    {
        DifficultySlider.value = DefaultDifficulty;
        LevelSlider.value = DefaultLevel;
        VolumeSlider.value = defaultVolume;
        PlayerPrefsController.SetMasterVolume(defaultVolume);
        PlayerPrefsController.SetDifficultyLevel(DefaultDifficulty);
    }
}
