using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour
{
    private MusicMethods music;

    private void Awake()
    {
        SetUpSingleton();

        //DontDestroyOnLoad(transform.gameObject);
        music = GetComponent<MusicMethods>();
    }

    private void SetUpSingleton()
    {
        music = GetComponent<MusicMethods>();
        music.startMusic();
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void NextSong() {  music.NextSong();   }
    public void PrevSong() {  music.PrevSong();   }
    public void VolumeUp() {  music.VolumeUp();   }
    public void VolumeDown(){ music.VolumeDown(); }
    public void PauseSong(){  music.PauseSong();  }
    public void PlaySong() {  music.PlaySong();   }

}
