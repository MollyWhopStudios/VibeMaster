using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData
{
    // enemy data mechanics --------------------------------------------------------------------------------
    private int level;
    public int GetLevel() { return level; }
    public void SetLevel(int level) { this.level = level; }

    //public int level   = 1;   // used to track how many enemies killed; how to scale enemy difficulty (health)
    private int baseReward;      // starting base point reward for killing enemy
    public int GetBaseReward() { return baseReward; }

    private int baseHealth;      // starting point for enemy health initialization
    public int GetBaseHealth() { return baseHealth; }

    private float rewardScaling; // scaling vibes earned after killing enemy
    public float GetRewardScaling() { return rewardScaling; }

    private float healthScaling; // used to reset enemy health values for higher levels
    public float GetHealthScaling() { return healthScaling; }

    private float health;        // enemy health values
    public float GetHealth() { return health; }
    public void SetHealth(float health) { this.health = health; }

    private float maxHealth;     // to use for calculating enemy health bar
    public float GetMaxHealth() { return maxHealth; }
    public void SetMaxHealth(float maxHealth) { this.maxHealth = maxHealth; }


    public EnemyData()
    {
        ResetData();
    }

    public void ResetData()
    {
        level      = 1;
        baseReward = 20;
        baseHealth = 10;
        rewardScaling = 1.1f;
        healthScaling = 1.5f;
        health = 0;
        maxHealth = 0;
        CalculateEnemyHealth();
    }

    public void CalculateEnemyHealth()
    {
        health = level * healthScaling * baseHealth;
        maxHealth = health;
    }
}
