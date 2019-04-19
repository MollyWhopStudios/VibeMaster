using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float gameOverDelayInSeconds = 3f;

    public GameObject shopPanel;
    public GameObject statsPanel;
    public GameObject miniMenuPanel;
    public GameObject musicPanel;
    public GameObject miniGamePanel;

    bool musicPanelOn = false; // for using same button to open and close music panel

    bool miniGamePanelOn = false; // for using same button to open and close mini game panel


    public AudioSource shopSound;
    public AudioSource miniMenuSound;
    public AudioSource statsSound;

    Animation slide;

    //private MusicPlayer currentSong;

    private void Start()
    {
        //currentSong = FindObjectOfType<MusicPlayer>();
    }

    public void musicPanelSlide()
    {
        slide = musicPanel.GetComponent<Animation>();
        if(musicPanelOn)
        {
            slide.Play("musicPanelSlideOff");
            musicPanelOn = false;
        }
        else
        {
            slide.Play("musicPanelSlide");
            musicPanelOn = true;
        }

    }

    public void OpenShopAnimation()
    {
        slide = shopPanel.GetComponent<Animation>();
        shopSound.Play();
        slide.Play("shopPanelSlide");
    }

    public void CloseShopAnimation()
    {
        slide = shopPanel.GetComponent<Animation>();
        shopSound.Play();
        slide.Play("shopPanelSlideOff");
    }

    public void OpenStatsAnimation()
    {
        slide = statsPanel.GetComponent<Animation>();
        statsSound.Play();
        slide.Play("statsPanelSlide");
    }


    public void CloseStatsAnimation()
    {
        slide = statsPanel.GetComponent<Animation>();
        statsSound.Play();
        slide.Play("statsPanelSlideOff");
    }

    public void OpenMiniMenuAnimation()
    {
        slide = miniMenuPanel.GetComponent<Animation>();
        miniMenuSound.Play();
        slide.Play("miniMenuPanelSlide");
    }


    public void CloseMiniMenuAnimation()
    {
        slide = miniMenuPanel.GetComponent<Animation>();
        miniMenuSound.Play();
        slide.Play("miniMenuPanelSlideOff");
    }

    public void MiniGamePanelAnimation()
    {
        slide = miniGamePanel.GetComponent<Animation>();
        if (miniGamePanelOn)
        {
            slide.Play("miniGamePanelSlideOff");
            miniGamePanelOn = false;
        }
        else
        {
            slide.Play("miniGamePanelSlide");
            miniGamePanelOn = true;
        }
    }


    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMenuScreen()
    {
        SceneManager.LoadScene("Main Menu");

    }

    public void LoadGameScreen()
    {
        SceneManager.LoadScene("Game");

        //currentSong.FadeOut();
        //currentSong.NextSong();

    }
    
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void LoadBulletHellGameOverScreen()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(gameOverDelayInSeconds);
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        // Auto Save on Quit
        PlayerManager data = FindObjectOfType<PlayerManager>(); ;
        data.Save();
        //
        Application.Quit();
    }


}
