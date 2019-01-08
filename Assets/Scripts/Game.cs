using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    // blacks
    // -------------------------------------------------------
    public GameObject critText; // animation to play when crit
    public GameObject clickImage; // main button to acquire clicks
    /* Images */
    public Sprite defaultStatue; 
    public Sprite critStatue;
    public Sprite critStatue1;
    public Sprite critStatue2;
    public Sprite critStatue3;
    // -------------------------------------------------------

    // cached data
    public PlayerData playerData;
    private Image tempImage;
    private int critAttack;
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        //extract image from game object to change it later
        tempImage = clickImage.GetComponent<Image>();
        score.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Vibes: " + playerData.click;
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
            playerData.click = playerData.click + (playerData.clickMultiplier * playerData.critMultiplier);
            critText.GetComponent<Text>().text = "クリティカル";
            critText.GetComponent<Animation>().Play("critAnimation");

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
        }
        else
        {
            playerData.click = playerData.click + playerData.clickMultiplier; //get 1 vibe for every click
            playerData.clickTotal = playerData.clickTotal + playerData.clickMultiplier;
            tempImage.sprite = defaultStatue; //change statue back to non-glitched
        }
    }
}
