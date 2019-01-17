using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopFunctions : MonoBehaviour
{
    [SerializeField] public PlayerManager data;
    public TextMeshProUGUI clickTierText, critTierText, passiveTierText;
    public TextMeshProUGUI clickCostText, critCostText, passiveCostText;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<PlayerManager>();

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
        scoreText.text = "Vibe: " + data.player.click;

        clickTierText.text = "Tier: " + data.player.GetUpgradeTier((int)PlayerData.Upgrades.click) + "\n(+" +
            data.player.clickUpgradeValue[(int)PlayerData.Upgrades.click] + " Vibes)";

        critTierText.text = "Tier: " + data.player.GetUpgradeTier((int)PlayerData.Upgrades.crit) + "\n(+%" +
            data.player.critUpgradeValue[(int)PlayerData.Upgrades.crit] + " Crit)";

        passiveTierText.text = "Tier: " + data.player.GetUpgradeTier((int)PlayerData.Upgrades.passive);

        clickCostText.text = "Cost: " + data.player.GetUpgradeCost((int)PlayerData.Upgrades.click);
        critCostText.text = "Cost: " + data.player.GetUpgradeCost((int)PlayerData.Upgrades.crit);
        passiveCostText.text = "Cost: " + data.player.GetUpgradeCost((int)PlayerData.Upgrades.passive);
    }

    public void ClickUpgrade()
    {
        data.player.ClickUpgrade();
    }

    public void CritUpgrade()
    {
        data.player.CritUpgrade();
    }

    public void PassiveUpgrade()
    {
        data.player.PassiveUpgrade();
    }
}
