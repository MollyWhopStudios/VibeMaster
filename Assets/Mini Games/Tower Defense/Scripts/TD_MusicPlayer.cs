using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_MusicPlayer : MonoBehaviour {

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = TD_PlayerPrefsController.GetMasterVolume();
	}
	
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
