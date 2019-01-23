using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
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
    // Player Controller -- Get data when scene loaded
    public PlayerManager data;
    // Wrappers 
    public void ResetData() { data.ResetData(); }
    public void Load() { data.Load(); }
    public void Save() { data.Save(); }
    //
    private Image tempImage;
    private int critAttack;
    public TextMeshProUGUI score;
    Animation death;
    // -------------------------------------------------------
    public string currentEnemyName;         // string variable to display names of current enemy
    public Image healthbar;                 // main healthbar
    public TextMeshProUGUI enemyHealthDisplay; // to display enemy health on main screen
    public TextMeshProUGUI levelDisplay;       // to display current level

    void Start()
    {
        // ---
        data = FindObjectOfType<PlayerManager>();
        // ---

        currentEnemyName = "Solidarity Statue"; // first enemy is the statue
        currentEnemy = defaultStatue;
        currentCrit1 = critStatue1;
        currentCrit2 = critStatue2;
        currentCrit3 = critStatue3;
        
        //extract image from game object to change it later
        tempImage = clickImage.GetComponent<Image>();
        score.GetComponent<TextMeshProUGUI>();
        enemyHealthDisplay.GetComponent<TextMeshProUGUI>();
        levelDisplay.GetComponent<TextMeshProUGUI>();

        death = clickImage.GetComponent<Animation>();
    }

    void Update()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        score.text = "Vibes: " + data.player.click;
        enemyHealthDisplay.text = "HP: " + data.enemy.GetHealth();
        levelDisplay.text = "Level: " + data.enemy.GetLevel() + " - " + currentEnemyName;
        healthbar.fillAmount = data.enemy.GetHealth() / data.enemy.GetMaxHealth();
    }

    public void ButtonClick()
    {
        if(data.enemy.GetHealth() > 0)
            Attack();
    }

    private void Attack()
    {
        critAttack = Random.Range(1, 101);

        if (data.player.critChance >= critAttack)
        {
            float tempHealth = data.enemy.GetHealth();
            //playerData.click = playerData.click + (playerData.clickMultiplier * playerData.critMultiplier);
            tempHealth -= (data.player.clickMultiplier * data.player.critMultiplier);

            if (tempHealth < 0) //so that no negatives show up
                tempHealth = 0;

            if (tempHealth == 0) // change picture + add vibes when enemy dies
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
            data.enemy.SetHealth(tempHealth);
        }
        else
        {
            float tempHealth = data.enemy.GetHealth();
            //playerData.click = playerData.click + playerData.clickMultiplier; //get 1 vibe for every click

            tempHealth -= data.player.clickMultiplier;

            if (tempHealth < 0) //so that no negatives show up
                tempHealth = 0;

            tempImage.sprite = currentEnemy; // to reset if crit image is the current

            if (tempHealth == 0) // change picture + add vibes when enemy dies
            {
                death.Play("deathAnimation");
                Invoke("RandomizeEnemyImage", 0.5f); // wait 30 frames before running function
            }

            //playerData.clickTotal = playerData.clickTotal + playerData.clickMultiplier;
            //tempImage.sprite = defaultStatue; //change statue back to non-glitched

            data.enemy.SetHealth(tempHealth);
        }
    }

    private void RandomizeEnemyImage()
    {
        data.player.click += (data.enemy.GetLevel() * data.enemy.GetBaseReward() * data.enemy.GetRewardScaling());
        data.LevelUp(); // increments both player and enemy stored data (level++)
        data.enemy.CalculateEnemyHealth();

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
