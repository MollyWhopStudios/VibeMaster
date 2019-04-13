using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFunctions : MonoBehaviour
{

    public AudioClip[] trackList;


    private MusicPlayer currentSong;

    public bool pause = false;

    int songTracker = 0;
    float volume;

    // Start is called before the first frame update
    void Start()
    {
        trackList = new AudioClip[] { (AudioClip)Resources.Load("guitar center"),
            (AudioClip)Resources.Load("Iced Apples"),
            (AudioClip)Resources.Load("lunar steps"),
            (AudioClip)Resources.Load("melody 7 flip"),
            (AudioClip)Resources.Load("sand"),
            (AudioClip)Resources.Load("molliwhop (final)")
        };

        currentSong = FindObjectOfType<MusicPlayer>();
        currentSong.ChangeSong(trackList[songTracker]);
        currentSong.SetVolume(0f);
        currentSong.PlaySong();
        currentSong.FadeIn();

        volume = currentSong.GetVolume();
    }

    private void Update()
    {
        if(!currentSong.isPlaying() && !pause)
        {
            if (songTracker == (trackList.Length - 1))
                songTracker = 0;
            else
                songTracker++;

            currentSong.StopSong();
            currentSong.ChangeSong(trackList[songTracker]);
            currentSong.SetVolume(volume);
            currentSong.PlaySong();
        }
    }


    public void NextSong()
    {
        if (songTracker == (trackList.Length - 1))
            songTracker = 0;
        else
            songTracker++;

        currentSong.StopSong();
        currentSong.ChangeSong(trackList[songTracker]);
        currentSong.SetVolume(volume);
        currentSong.PlaySong();
    }

    public void PrevSong()
    {
        if (songTracker == 0)
            songTracker = trackList.Length - 1;
        else
            songTracker--;

        currentSong.StopSong();
        currentSong.ChangeSong(trackList[songTracker]);
        currentSong.SetVolume(volume);
        currentSong.PlaySong();
    }

    public void VolumeUp()
    {
        currentSong.VolumeUp();
        volume = currentSong.GetVolume();
    }

    public void VolumeDown()
    {
        currentSong.VolumeDown();
        volume = currentSong.GetVolume();
    }

    public void PauseSong()
    {
        currentSong.PauseSong();
        pause = true;
    }

    public void PlaySong()
    {
        //if (currentSong.clip.name == newSong.name)
          //  return;

        currentSong.PlaySong();
        pause = false;
    }

}
