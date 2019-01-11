using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float gameOverDelayInSeconds = 3f;

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
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadShopScreen()
    {
        SceneManager.LoadScene("Shop");
    }

    public void LoadStatsScreen()
    {
        SceneManager.LoadScene("Stats");
    }

    public void LoadMiniGameScreen()
    {
        SceneManager.LoadScene("Mini Games");
    }

    public void LoadTowerDefenseScreen()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadBulletHellScreen()
    {
        SceneManager.LoadScene("Bullet Hell");
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
        Application.Quit();
    }
}
