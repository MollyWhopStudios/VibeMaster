using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource currentSong;

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

    /*
    private void playSong()
    {
        currentSong.Play();
    }
    */


    public void PlaySong()
    {
        currentSong.Play();
    }

    public void StopSong()
    {
        currentSong.Stop();
    }

    public void PauseSong()
    {
        currentSong.Pause();
    }


    public void SetVolume(float newVolume)
    {
        currentSong.volume = newVolume;
    }

    public float GetVolume()
    {
        return currentSong.volume;
    }

    public void ChangeSong(AudioClip newSong)
    {
        if (currentSong.clip.name == newSong.name)
            return;

        currentSong.Stop();
        currentSong.clip = newSong;
        currentSong.Play();
    }

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
            currentSong.volume += 0.05f;
    }

    public void VolumeDown()
    {
        if(currentSong.volume > 0)
            currentSong.volume -= 0.05f;
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
        while (currentSong.volume < 1)
        {
            currentSong.volume += (float)0.01;
            yield return new WaitForSeconds(0.03f);
        }

        StopCoroutine(FadeI());
    }

}
