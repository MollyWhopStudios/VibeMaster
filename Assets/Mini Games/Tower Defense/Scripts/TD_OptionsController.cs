using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TD_OptionsController : MonoBehaviour {

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0f;

    // Use this for initialization
    void Start ()
    {
        volumeSlider.value = TD_PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = TD_PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update ()
    {
        var musicPlayer = FindObjectOfType<TD_MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found... did you start from splash screen?");
        }
	}

    public void SaveAndExit()
    {
        TD_PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        TD_PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<TD_LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
