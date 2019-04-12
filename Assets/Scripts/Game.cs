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

    public TextMeshProUGUI ticketTextDisplay; // temp text variable for # of tickets

    public AudioSource critSound; // holds the crit sound

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

    public Sprite dolphinEnemy1;
    public Sprite critDolphin1red;
    public Sprite critDolphin2red;
    public Sprite critDolphin3red;

    public Sprite dolphinEnemy2;
    public Sprite critDolphin1green;
    public Sprite critDolphin2green;
    public Sprite critDolphin3green;

    public Sprite dolphinEnemy3;
    public Sprite critDolphin1blue;
    public Sprite critDolphin2blue;
    public Sprite critDolphin3blue;

    public Sprite kingPalmEnemy1;
    public Sprite critPalm1Red;
    public Sprite critPalm2Red;
    public Sprite critPalm3Red;

    public Sprite kingPalmEnemy2;
    public Sprite critPalm1Green;
    public Sprite critPalm2Green;
    public Sprite critPalm3Green;

    public Sprite kingPalmEnemy3;
    public Sprite critPalm1Blue;
    public Sprite critPalm2Blue;
    public Sprite critPalm3Blue;

    public Sprite beetle;
    public Sprite critBeetle1;
    public Sprite critBeetle2;
    public Sprite critBeetle3;

    public Sprite microwave;
    public Sprite critMicrowave1;
    public Sprite critMicrowave2;
    public Sprite critMicrowave3;

    public Sprite VHS;
    public Sprite critVHS1;
    public Sprite critVHS2;
    public Sprite critVHS3;

    public Sprite hotboydogEnemy;


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
    private int randomizer;
    public TextMeshProUGUI score;

    Animation clickImageAnimation;

    // enemy data mechanics --------------------------------------------------------------------------------
    [Header("Enemy Data")]
    public int level = 1;           // used to track how many enemies killed; how to scale enemy difficulty (health)
    public int baseReward = 20;          // starting base point reward for killing enemy
    public int baseHealth = 10;          // starting point for enemy health initialization
    public float rewardScaling = 1.1f; // scaling vibes earned after killing enemy
    public float enemyHealthScaling = 1.5f; // used to reset enemy health values for higher levels
    public float enemyHealth = 0;    // enemy health values
    public float enemyMaxHealth = 0;    // to use for calculating enemy health bar


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

        clickImageAnimation = clickImage.GetComponent<Animation>();

        ticketTextDisplay.GetComponent<TextMeshProUGUI>(); //get component for ticket number content display
    }

    void Update()
    {
        // ---------- mechanic to randomize idle enemy animation -------------
        if (!clickImageAnimation.isPlaying)
        {
            randomizer = Random.Range(1, 3);
            switch (randomizer)
            {
                case 1:
                    clickImageAnimation.PlayQueued("idleEnemyWiggle");
                    break;
                case 2:
                    clickImageAnimation.PlayQueued("idleEnemyPulse");
                    break;
            }
        }
        //---------------------------------------------------------------------
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        score.text = "Vibes: " + data.player.click;
        enemyHealthDisplay.text = "HP: " + data.enemy.GetHealth();
        levelDisplay.text = "Level: " + data.enemy.GetLevel() + " - " + currentEnemyName;
        healthbar.fillAmount = data.enemy.GetHealth() / data.enemy.GetMaxHealth();

        ticketTextDisplay.text = "x " + 0;
    }

    public void ButtonClick()
    {
        if (data.enemy.GetHealth() > 0)
            Attack();

        //data.player.clickTotal++;
    }

    private void Attack()
    {
        randomizer = Random.Range(1, 101);

        if (data.player.critChance >= randomizer)
        {
            float tempHealth = data.enemy.GetHealth();
            //playerData.click = playerData.click + (playerData.clickMultiplier * playerData.critMultiplier);
            tempHealth -= (data.player.clickMultiplier * data.player.critMultiplier);

            critSound.Play();

            if (tempHealth < 0) //so that no negatives show up
                tempHealth = 0;

            if (tempHealth == 0) // change picture + add vibes when enemy dies
            {
                clickImageAnimation.Play("deathAnimation");
                Invoke("RandomizeEnemyImage", 0.5f); // wait 30 frames before running function
            }

            critText.GetComponent<Text>().text = "クリティカル";
            critText.GetComponent<Animation>().Play("critAnimation");

            // NEED MORE CRIT IMAGES BEFORE IMPLEMENTING THIS PART JK

            randomizer = Random.Range(1, 4);
            switch (randomizer)
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
            data.enemy.SetHealth(tempHealth);
        } //end if
        
        

        else
        {
            float tempHealth = data.enemy.GetHealth();
            //playerData.click = playerData.click + playerData.clickMultiplier; //get 1 vibe for every click

            tempHealth -= data.player.clickMultiplier;

            if (tempHealth < 0) //so that no negatives show up
                tempHealth = 0;

            tempImage.sprite = currentEnemy; // to reset to non crit image if crit image is the current

            if (tempHealth == 0) // change picture + add vibes when enemy dies
            {
                clickImageAnimation.Play("deathAnimation");
                Invoke("RandomizeEnemyImage", 0.5f); // wait 30 frames before running function
            }

            //playerData.clickTotal = playerData.clickTotal + playerData.clickMultiplier;
            //tempImage.sprite = defaultStatue; //change statue back to non-glitched
            data.enemy.SetHealth(tempHealth);
        } //end else
    } //end attack() function

            


    private void RandomizeEnemyImage()
    {
        data.player.click += (data.enemy.GetLevel() * data.enemy.GetBaseReward() * data.enemy.GetRewardScaling());
        data.player.clickTotal += (data.enemy.GetLevel() * data.enemy.GetBaseReward() * data.enemy.GetRewardScaling());

        data.LevelUp(); // increments both player and enemy stored data (level++)
        data.enemy.CalculateEnemyHealth();

        //data.player.clickTotal += data.player.click;

        

        int imageSelector = Random.Range(1, 12);
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
                currentEnemy = dolphinEnemy1;
                currentCrit1 = critDolphin1red;
                currentCrit2 = critDolphin2red;
                currentCrit3 = critDolphin3red;
                tempImage.sprite = dolphinEnemy1;
                currentEnemyName = "Didactic Dolphin Squad One";
                break;
            case 3:
                currentEnemy = dolphinEnemy2;
                currentCrit1 = critDolphin1green;
                currentCrit2 = critDolphin2green;
                currentCrit3 = critDolphin3green;
                tempImage.sprite = dolphinEnemy2;
                currentEnemyName = "Didactic Dolphin Squad Two";
                break;
            case 4:
                currentEnemy = dolphinEnemy3;
                currentCrit1 = critDolphin1blue;
                currentCrit2 = critDolphin2blue;
                currentCrit3 = critDolphin3blue;
                tempImage.sprite = dolphinEnemy3;
                currentEnemyName = "Didactic Dolphin Squad Three";
                break;
            case 5:
                currentEnemy = hotboydogEnemy;
                //currentCrit1 = null;
                //currentCrit2 = null;
                //currentCrit3 = null;
                tempImage.sprite = hotboydogEnemy;
                currentEnemyName = "Halcyon HotDog Man";
                break;
            case 6:
                currentEnemy = kingPalmEnemy1;
                currentCrit1 = critPalm1Red;
                currentCrit2 = critPalm2Red;
                currentCrit3 = critPalm3Red;
                tempImage.sprite = kingPalmEnemy1;
                currentEnemyName = "Kindred King Palm I";
                break;
            case 7:
                currentEnemy = kingPalmEnemy2;
                currentCrit1 = critPalm1Green;
                currentCrit2 = critPalm2Green;
                currentCrit3 = critPalm3Green;
                tempImage.sprite = kingPalmEnemy2;
                currentEnemyName = "Kindred King Palm II";
                break;
            case 8:
                currentEnemy = kingPalmEnemy3;
                currentCrit1 = critPalm1Blue;
                currentCrit2 = critPalm2Blue;
                currentCrit3 = critPalm3Blue;
                tempImage.sprite = kingPalmEnemy3;
                currentEnemyName = "Kindred King Palm III";
                break;

            case 9:
                currentEnemy = beetle;
                currentCrit1 = critBeetle1;
                currentCrit2 = critBeetle2;
                currentCrit3 = critBeetle3;
                tempImage.sprite = beetle;
                currentEnemyName = "Big Ballin Beetle";
                break;

            case 10:
                currentEnemy = microwave;
                currentCrit1 = critMicrowave1;
                currentCrit2 = critMicrowave2;
                currentCrit3 = critMicrowave3;
                tempImage.sprite = microwave;
                currentEnemyName = "Magnanimous Microwave";
                break;

            case 11:
                currentEnemy = VHS;
                currentCrit1 = critVHS1;
                currentCrit2 = critVHS2;
                currentCrit3 = critVHS3;
                tempImage.sprite = VHS;
                currentEnemyName = "Volumptuous VHS";
                break;

        } //end switch
    } // end RandomizeEnemyImage() function
} // end main
