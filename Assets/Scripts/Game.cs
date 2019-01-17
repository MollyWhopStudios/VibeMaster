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

    [HideInInspector] public Sprite currentEnemy; // picture to reset from crit image
    [HideInInspector] public Sprite currentCrit1; // temp crit images
    [HideInInspector] public Sprite currentCrit2;
    [HideInInspector] public Sprite currentCrit3;

    public Sprite defaultStatue; 
    public Sprite critStatue1;
    public Sprite critStatue2;
    public Sprite critStatue3;

    public Sprite dolphinEnemy2;
    public Sprite dolphinEnemy3;
    public Sprite hotboydogEnemy;
    public Sprite kingPalmEnemy;

    // -------------------------------------------------------

    // cached data
    [Header("Cached Data")]
    public PlayerManager data;
    private Image tempImage;
    private int critAttack;
    public TextMeshProUGUI score;
    Animation death;

    // enemy data mechanics --------------------------------------------------------------------------------
    [Header("Enemy Data")]
    public int level         = 1;           // used to track how many enemies killed; how to scale enemy difficulty (health)
    public int baseReward    = 20;          // starting base point reward for killing enemy
    public int baseHealth    = 10;          // starting point for enemy health initialization
    public float rewardScaling      = 1.1f; // scaling vibes earned after killing enemy
    public float enemyHealthScaling = 1.5f; // used to reset enemy health values for higher levels
    public float enemyHealth        = 0;    // enemy health values
    public float enemyMaxHealth     = 0;    // to use for calculating enemy health bar

    public string currentEnemyName;         // string variable to display names of current enemy

    public Image healthbar;                 // main healthbar

    public TextMeshProUGUI enemyHealthDisplay; // to display enemy health on main screen
    public TextMeshProUGUI levelDisplay;       // to display current level

    void Start()
    {
        //
        player = FindObjectOfType<PlayerManager>();
        //
        enemyHealth = level * enemyHealthScaling * baseHealth;
        enemyMaxHealth = enemyHealth;
        currentEnemyName = "Solidarity Statue"; // first enemy is the statue
        currentEnemy = defaultStatue;
        currentCrit1 = critStatue1;
        currentCrit2 = critStatue2;
        currentCrit3 = critStatue3;

        data = FindObjectOfType<PlayerManager>();
        //extract image from game object to change it later
        tempImage = clickImage.GetComponent<Image>();
        score.GetComponent<TextMeshProUGUI>();
        enemyHealthDisplay.GetComponent<TextMeshProUGUI>();
        levelDisplay.GetComponent<TextMeshProUGUI>();

        death = clickImage.GetComponent<Animation>();
    }

    void Update()
    {
        score.text = "Vibes: " + data.player.click;
        enemyHealthDisplay.text = "HP: " + enemyHealth;
        levelDisplay.text = "Level: " + level + " - " + currentEnemyName;
        healthbar.fillAmount = enemyHealth / enemyMaxHealth;
    }

    public void ButtonClick()
    {
        if(enemyHealth > 0)
            Attack();
    }

    private void Attack()
    {
        critAttack = Random.Range(1, 101);

        if (data.player.critChance >= critAttack)
        {
            //playerData.click = playerData.click + (playerData.clickMultiplier * playerData.critMultiplier);
            enemyHealth -= (data.player.clickMultiplier * data.player.critMultiplier);

            if (enemyHealth < 0) //so that no negatives show up
                enemyHealth = 0;

            if (enemyHealth == 0) // change picture + add vibes when enemy dies
            {
                death.Play("deathAnimation");
                Invoke("RandomizeEnemyImage", 0.5f); // wait 30 frames before running function
            }
                
            critText.GetComponent<Text>().text = "クリティカル";
            critText.GetComponent<Animation>().Play("critAnimation");

            /* NEED MORE CRIT IMAGES BEFORE IMPLEMENTING THIS PART
            int imageSelector = Random.Range(1, 4);
            switch (imageSelector)
            {
                case 1:
                    tempImage.sprite = currentCrit1;
                    break;
                case 2:
                    tempImage.sprite = currentCrit2;
                    break;
                case 3:
                    tempImage.sprite = currentCrit3;
                    break;
            }
            */

        }
        else
        {
            //playerData.click = playerData.click + playerData.clickMultiplier; //get 1 vibe for every click

            enemyHealth -= data.player.clickMultiplier;

            if (enemyHealth < 0) //so that no negatives show up
                enemyHealth = 0;

            tempImage.sprite = currentEnemy; // to reset if crit image is the current

            if (enemyHealth == 0) // change picture + add vibes when enemy dies
            {
                death.Play("deathAnimation");
                Invoke("RandomizeEnemyImage", 0.5f); // wait 30 frames before running function
            }

            //playerData.clickTotal = playerData.clickTotal + playerData.clickMultiplier;
            //tempImage.sprite = defaultStatue; //change statue back to non-glitched
        }
    }

    private void RandomizeEnemyImage()
    {

        data.player.click += (level * baseReward * rewardScaling);
        level++;
        enemyHealth = level * enemyHealthScaling * baseHealth;
        enemyMaxHealth = enemyHealth;

        data.player.clickTotal += data.player.click;

        int imageSelector = Random.Range(1, 6);
        switch (imageSelector)
        {
            case 1:
                currentEnemy = defaultStatue;
                currentCrit1 = critStatue1;
                currentCrit2 = critStatue2;
                currentCrit3 = critStatue3;
                tempImage.sprite = defaultStatue;
                currentEnemyName = "Solidarity Statue";
                break;
            case 2:
                currentEnemy = dolphinEnemy2;
                //currentCrit1 = ;
                //currentCrit2 = ;
                //currentCrit3 = ;
                tempImage.sprite = dolphinEnemy2;
                currentEnemyName = "Didactic Dolphin Squad One";
                break;
            case 3:
                currentEnemy = dolphinEnemy3;
                //currentCrit1 = ;
                //currentCrit2 = ;
                //currentCrit3 = ;
                tempImage.sprite = dolphinEnemy3;
                currentEnemyName = "Didactic Dolphin Squad Two";
                break;
            case 4:
                currentEnemy = hotboydogEnemy;
                //currentCrit1 = ;
                //currentCrit2 = ;
                //currentCrit3 = ;
                tempImage.sprite = hotboydogEnemy;
                currentEnemyName = "Halcyon HotDog Man";
                break;
            case 5:
                currentEnemy = kingPalmEnemy;
                //currentCrit1 = ;
                //currentCrit2 = ;
                //currentCrit3 = ;
                tempImage.sprite = kingPalmEnemy;
                currentEnemyName = "Kindred King Palm";
                break;
        }
    }
}
