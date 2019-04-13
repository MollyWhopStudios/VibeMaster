using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFunctions : MonoBehaviour
{
    public AudioClip[] song;


    private MusicPlayer currentSong;

    int songTracker = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentSong = FindObjectOfType<MusicPlayer>();
        currentSong.ChangeSong(song[songTracker]);
        currentSong.SetVolume(0f);
        currentSong.PlaySong();
        currentSong.FadeIn();
    }

    public void NextSong()
    {
        if (songTracker == (song.Length - 1))
            songTracker = 0;
        else
            songTracker++;

        currentSong.StopSong();
        currentSong.ChangeSong(song[songTracker]);
        currentSong.PlaySong();


    }




}
