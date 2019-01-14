using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    // blacks
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
    public PlayerData playerData;
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

    public TextMeshProUGUI enemyHealthDisplay; // to display enemy health on main screen
    public TextMeshProUGUI levelDisplay;       // to display current level

    void Start()
    {
        enemyHealth = level * enemyHealthScaling * baseHealth;

        playerData = FindObjectOfType<PlayerData>();
        //extract image from game object to change it later
        tempImage = clickImage.GetComponent<Image>();
        score.GetComponent<TextMeshProUGUI>();
        enemyHealthDisplay.GetComponent<TextMeshProUGUI>();
        levelDisplay.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        score.text = "Vibes: " + playerData.click;
        enemyHealthDisplay.text = "Enemy Health: " + enemyHealth;
        levelDisplay.text = "Level: " + level;
    }

    public void ButtonClick()
    {
        Attack();
    }

    private void Attack()
    {
        critAttack = Random.Range(1, 101);

        if (playerData.critChance >= critAttack)
        {
            //playerData.click = playerData.click + (playerData.clickMultiplier * playerData.critMultiplier);

            enemyHealth -= (playerData.clickMultiplier * playerData.critMultiplier);

            if (enemyHealth <= 0)
            {
                playerData.click += (level * baseReward * rewardScaling);
                level++;
                enemyHealth = level * enemyHealthScaling * baseHealth;

                int imageSelector = Random.Range(1, 4);
                switch (imageSelector)
                {
                    case 1:
                        tempImage.sprite = defaultStatue;
                        break;
                    case 2:
                        tempImage.sprite = enemy2;
                        break;
                    case 3:
                        tempImage.sprite = enemy3;
                        break;
                }
                playerData.clickTotal += playerData.click;
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

            enemyHealth -= playerData.clickMultiplier;

            if(enemyHealth <= 0)
            {
                playerData.click += (level * baseReward * rewardScaling);
                level++;
                enemyHealth = level * enemyHealthScaling * baseHealth;

                int imageSelector = Random.Range(1, 4);
                switch (imageSelector)
                {
                    case 1:
                        tempImage.sprite = defaultStatue;
                        break;
                    case 2:
                        tempImage.sprite = enemy2;
                        break;
                    case 3:
                        tempImage.sprite = enemy3;
                        break;
                }

                playerData.clickTotal += playerData.click;
            }

            //playerData.clickTotal = playerData.clickTotal + playerData.clickMultiplier;
            //tempImage.sprite = defaultStatue; //change statue back to non-glitched
        }
    }
}
