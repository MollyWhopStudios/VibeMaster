using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopFunctions : MonoBehaviour
{
    [SerializeField] public PlayerData playerData;
    public TextMeshProUGUI clickTierText, critTierText, passiveTierText;
    public TextMeshProUGUI clickCostText, critCostText, passiveCostText;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerData = FindObjectOfType<PlayerData>();

        scoreText.GetComponent<TextMeshProUGUI>();

        clickTierText.GetComponent<TextMeshProUGUI>();
        critTierText.GetComponent<TextMeshProUGUI>();
        passiveTierText.GetComponent<TextMeshProUGUI>();

        clickCostText.GetComponent<TextMeshProUGUI>();
        critCostText.GetComponent<TextMeshProUGUI>();
        passiveCostText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Vibe: " + playerData.click;

        clickTierText.text = "Tier: " + playerData.GetUpgradeTier((int)PlayerData.Upgrades.click) + "\n(+" + 
            playerData.clickUpgradeValue[(int)PlayerData.Upgrades.click] + " Vibes)";

        critTierText.text = "Tier: " + playerData.GetUpgradeTier((int)PlayerData.Upgrades.crit) + "\n(+%" + 
            playerData.critUpgradeValue[(int)PlayerData.Upgrades.crit] + " Crit)";

        passiveTierText.text = "Tier: " + playerData.GetUpgradeTier((int)PlayerData.Upgrades.passive);

        clickCostText.text = "Cost: " + playerData.GetUpgradeCost((int)PlayerData.Upgrades.click);
        critCostText.text = "Cost: " + playerData.GetUpgradeCost((int)PlayerData.Upgrades.crit);
        passiveCostText.text = "Cost: " + playerData.GetUpgradeCost((int)PlayerData.Upgrades.passive);
    }

    public void ClickUpgrade()
    {
        playerData.ClickUpgrade();
    }

    public void CritUpgrade()
    {
        playerData.CritUpgrade();
    }

    public void PassiveUpgrade()
    {
        playerData.PassiveUpgrade();
    }
}
