using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    // Player Controller -- Get data when scene loaded
    PlayerManager player;
    // Wrappers 
    public void ResetData() { player.ResetData(); }
    public void Load() { player.Load(); }
    public void Save() { player.Save(); }
    // -------------------------------------------------------
    public GameObject critText;   // animation to play when crit
    public GameObject clickImage; // main button to acquire clicks
    /* Images */
    [Header("Image Data")]
    public Sprite defaultStatue; 
    public Sprite critStatue;
    public Sprite critStatue1;
    public Sprite critStatue2;
    public Sprite critStatue3;
    public Sprite enemy2;
    public Sprite enemy3;

    // -------------------------------------------------------

    // cached data
    [Header("Cached Data")]
    public PlayerManager data;
    private Image tempImage;
    private int critAttack;
    public TextMeshProUGUI score;

    // enemy data mechanics --------------------------------------------------------------------------------
    [Header("Enemy Data")]
    public int level         = 1;           // used to track how many enemies killed; how to scale enemy difficulty (health)
    public int baseReward    = 20;          // starting base point reward for killing enemy
    public int baseHealth    = 10;          // starting point for enemy health initialization
    public float rewardScaling      = 1.1f; // scaling vibes earned after killing enemy
    public float enemyHealthScaling = 1.5f; // used to reset enemy health values for higher levels
    public float enemyHealth        = 0;    // enemy health values

    public string currentEnemyName;         // string variable to display names of current enemy

    public TextMeshProUGUI enemyHealthDisplay; // to display enemy health on main screen
    public TextMeshProUGUI levelDisplay;       // to display current level

    void Start()
    {
        //
        player = FindObjectOfType<PlayerManager>();
        //
        enemyHealth = level * enemyHealthScaling * baseHealth;
        currentEnemyName = "Solidarity Statue"; // first enemy is the statue

        data = FindObjectOfType<PlayerManager>();
        //extract image from game object to change it later
        tempImage = clickImage.GetComponent<Image>();
        score.GetComponent<TextMeshProUGUI>();
        enemyHealthDisplay.GetComponent<TextMeshProUGUI>();
        levelDisplay.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        score.text = "Vibes: " + data.player.click;
        enemyHealthDisplay.text = "Enemy Health: " + enemyHealth;
        levelDisplay.text = "Level: " + level + " - " + currentEnemyName;
    }

    public void ButtonClick()
    {
        Attack();
    }

    private void Attack()
    {
        critAttack = Random.Range(1, 101);

        if (data.player.critChance >= critAttack)
        {
            //playerData.click = playerData.click + (playerData.clickMultiplier * playerData.critMultiplier);

            enemyHealth -= (data.player.clickMultiplier * data.player.critMultiplier);

            if (enemyHealth <= 0)
            {
                data.player.click += (level * baseReward * rewardScaling);
                level++;
                enemyHealth = level * enemyHealthScaling * baseHealth;

                int imageSelector = Random.Range(1, 4);
                switch (imageSelector)
                {
                    case 1:
                        tempImage.sprite = defaultStatue;
                        currentEnemyName = "Solidarity Statue";
                        break;
                    case 2:
                        tempImage.sprite = enemy2;
                        currentEnemyName = "Didactic Dolphin Squad One";
                        break;
                    case 3:
                        tempImage.sprite = enemy3;
                        currentEnemyName = "Didactic Dolphin Squad Two";
                        break;
                }
                data.player.clickTotal += data.player.click;
            }

            critText.GetComponent<Text>().text = "クリティカル";
            critText.GetComponent<Animation>().Play("critAnimation");

            /*
            int imageSelector = Random.Range(1, 5);

            // change image to "glitch" when critting
            if (imageSelector == 1)
            {
                tempImage.sprite = critStatue1;
            }
            else if (imageSelector == 2)
            {
                tempImage.sprite = critStatue2;
            }
            else if (imageSelector == 3)
            {
                tempImage.sprite = critStatue3;
            }
            else
            {
                tempImage.sprite = critStatue;
            }
            */

        }
        else
        {
            //playerData.click = playerData.click + playerData.clickMultiplier; //get 1 vibe for every click

            enemyHealth -= data.player.clickMultiplier;

            if(enemyHealth <= 0)
            {
                data.player.click += (level * baseReward * rewardScaling);
                level++;
                enemyHealth = level * enemyHealthScaling * baseHealth;

                int imageSelector = Random.Range(1, 4);
                switch (imageSelector)
                {
                    case 1:
                        tempImage.sprite = defaultStatue;
                        currentEnemyName = "Solidarity Statue";
                        break;
                    case 2:
                        tempImage.sprite = enemy2;
                        currentEnemyName = "Didactic Dolphin Squad One";
                        break;
                    case 3:
                        tempImage.sprite = enemy3;
                        currentEnemyName = "Didactic Dolphin Squad Two";
                        break;
                }

                data.player.clickTotal += data.player.click;
            }

            //playerData.clickTotal = playerData.clickTotal + playerData.clickMultiplier;
            //tempImage.sprite = defaultStatue; //change statue back to non-glitched
        }
    }
}
