using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Player Data
    [SerializeField] public int click = 0;
    [SerializeField] public int clickTotal = 0;
    [SerializeField] public int clickMultiplier = 1;
    [SerializeField] public float critChance = 1f;
    [SerializeField] public int critMultiplier = 3;
    [SerializeField] public int passiveGain = 0;

    // Shop Values
    public enum Upgrades { click, crit, passive };
    [Header("Shop Upgrades")]
    private int shopUpgradeMaxLevel = 4; // size of value array
    [SerializeField] public int scaleLevel = 5; // num of cycles before scale to new level
    private int[] shopUpgradeLevel = { 0, 0, 0 };
    private int[] upgradeScaleCounter = { 0, 0, 0 };

    public int GetUpgradeTier(int upgrade) { return shopUpgradeLevel[upgrade]; }

    [Header("Click Upgrades")]
    [SerializeField] public int[] clickUpgradeCost = { 10, 1000, 1000, 10000, 100000 };
    [SerializeField] public int[] clickUpgradeValue = { 1, 10, 100, 1000, 10000 };
    [Header("Crit Upgrades")]
    [SerializeField] public int[] critUpgradeCost = { 10, 1000, 1000, 10000, 100000 };
    [SerializeField] public float[] critUpgradeValue = { 0.5f, 1.0f, 5.0f, 7.5f, 10.0f };
    [Header("Passive Upgrades")]
    [SerializeField] public int[] passiveUpgradeCost = { 1000, 10000, 100000, 1000000, 100000000 };
    [SerializeField] public int[] passiveUpgradeValue = { 3, 30, 100, 500, 10000 };

    public int GetUpgradeCost(int upgrade)
    {
        switch (upgrade)
        {
            case 0: return clickUpgradeCost[shopUpgradeLevel[(int)Upgrades.click]];
            case 1: return critUpgradeCost[shopUpgradeLevel[(int)Upgrades.crit]];
            case 2: return passiveUpgradeCost[shopUpgradeLevel[(int)Upgrades.passive]];
            default: return -1;
        }
    }

    // Singleton ------------------------------------ DONT TOUCH
    private void Awake() { SetUpSingleton(); }
    private void SetUpSingleton() {
        if (FindObjectsOfType(GetType()).Length > 1) { Destroy(gameObject); }
        else { DontDestroyOnLoad(gameObject); }
    } // End Singleton ------------------------------ DONT TOUCH

    private void Update()
    {
        // passive upgrades
        // TODO:
    }

    private void UseUpgrade(int upgrade)
    {
        if (upgradeScaleCounter[upgrade] < scaleLevel)
        {
            upgradeScaleCounter[upgrade]++;
        }
        else
        {
            upgradeScaleCounter[upgrade] = 0;
            if (shopUpgradeLevel[upgrade] < shopUpgradeMaxLevel)
            {
                shopUpgradeLevel[upgrade]++;
            }
        }
    }

    public void ClickUpgrade()
    {
        int cost = clickUpgradeCost[shopUpgradeLevel[(int)Upgrades.click]];
        if (click >= cost)
        {
            click = click - cost;
            clickMultiplier = clickMultiplier + clickUpgradeValue[shopUpgradeLevel[(int)Upgrades.click]];
            UseUpgrade((int)Upgrades.click);
        }
    }

    public void CritUpgrade()
    {
        int cost = critUpgradeCost[shopUpgradeLevel[(int)Upgrades.crit]];
        if (click >= cost && critChance < 100)
        {
            click = click - cost;
            critChance = critChance + critUpgradeValue[shopUpgradeLevel[(int)Upgrades.crit]];
            UseUpgrade((int)Upgrades.crit);
        }
    }

    public void PassiveUpgrade()
    {
        int cost = passiveUpgradeCost[shopUpgradeLevel[(int)Upgrades.passive]];
        if (click >= cost && critChance < 100)
        {
            click = click - cost;
            // TODO: add passive clicks
        }
    }

}
