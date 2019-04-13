using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicFunctions : MonoBehaviour
{

    private MusicPlayer currentSong;

    public TextMeshProUGUI songNameDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentSong = FindObjectOfType<MusicPlayer>();
    }

    public void NextSong()
    {
        currentSong.NextSong();
    }

    public void PrevSong()
    {
        currentSong.PrevSong();
    }

    public void VolumeUp()
    {
        currentSong.VolumeUp();
        //volume = currentSong.GetVolume();
    }

    public void VolumeDown()
    {
        currentSong.VolumeDown();
        //volume = currentSong.GetVolume();
    }

    public void PauseSong()
    {
        currentSong.PauseSong();
    }

    public void PlaySong()
    {
        
        currentSong.PlaySong();
    }

}
