using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicPlayer : MonoBehaviour
{

    private AudioClip[] trackList;

    public AudioSource currentSong;

    public TextMeshProUGUI songNameDisplay;

    int songTracker = 0;
    float volume;
    public bool pause = false;



    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        songNameDisplay.GetComponent<TextMeshProUGUI>();

        trackList = new AudioClip[] { (AudioClip) Resources.Load("guitar center"),
            (AudioClip) Resources.Load("Iced Apples"),
            (AudioClip) Resources.Load("lunar steps"),
            (AudioClip) Resources.Load("melody 7 flip"),
            (AudioClip) Resources.Load("sand"),
            (AudioClip) Resources.Load("molliwhop (final)")
        };

        volume = currentSong.volume;


        currentSong.Stop();
        currentSong.clip = trackList[songTracker];
        currentSong.volume = 0f;
        currentSong.Play();
        StartCoroutine(FadeI());

    }

    private void Update()
    {
        if (!currentSong.isPlaying && !pause)
        {
            if (songTracker == (trackList.Length - 1))
                songTracker = 0;
            else
                songTracker++;

            
            currentSong.Stop();
            currentSong.clip = trackList[songTracker];
            currentSong.volume = volume;
            currentSong.Play();
        }

        songNameDisplay.text = currentSong.clip.name;
    }

    public void NextSong()
    {
        if (songTracker == (trackList.Length - 1))
            songTracker = 0;
        else
            songTracker++;

        currentSong.Stop();
        currentSong.clip = trackList[songTracker];
        currentSong.volume = volume;
        currentSong.Play();
    }

    public void PrevSong()
    {
        if (songTracker == 0)
            songTracker = trackList.Length - 1;
        else
            songTracker--;

        currentSong.Stop();
        currentSong.clip = trackList[songTracker];
        currentSong.volume = volume;
        currentSong.Play();
    }



    public void PlaySong()
    {
        if (currentSong.clip.name == trackList[songTracker].name && !pause)
            return;

        currentSong.Play();
        pause = false;
    }

    public void StopSong()
    {
        currentSong.Stop();
    }

    public void PauseSong()
    {
        currentSong.Pause();
        pause = true;
    }


    public void SetVolume(float newVolume)
    {
        currentSong.volume = newVolume;
    }

    public float GetVolume()
    {
        return currentSong.volume;
    }

    /*
    public void ChangeSong(AudioClip newSong)
    {
        if (currentSong.clip.name == newSong.name)
            return;

        currentSong.Stop();
        currentSong.clip = newSong;
        currentSong.Play();
    }
    */

    public void FadeOut()
    {
        StartCoroutine(FadeO());
    }

    public void FadeIn()
    {
        StartCoroutine(FadeI());
    }

    public void VolumeUp()
    {
        if(currentSong.volume < 1)
        {
            volume += 0.025f;
            currentSong.volume = volume;
        }
            
    }

    public void VolumeDown()
    {
        if(currentSong.volume > 0)
        {
            volume -= 0.025f;
            currentSong.volume = volume;
        }
    }

    public bool isPlaying()
    {
        return currentSong.isPlaying;
    }

    private IEnumerator FadeO()
    {
        while (currentSong.volume > 0)
        {
            currentSong.volume -= (float)0.01;
            yield return new WaitForSeconds(0.03f);
        }

        currentSong.Stop();

        StopCoroutine(FadeO());
    }

    private IEnumerator FadeI()
    {
        while (currentSong.volume < volume)
        {
            currentSong.volume += (float)0.01;
            yield return new WaitForSeconds(0.03f);
        }

        StopCoroutine(FadeI());
    }

}
